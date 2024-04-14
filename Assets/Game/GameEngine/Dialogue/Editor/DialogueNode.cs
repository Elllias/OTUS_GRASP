#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.GameEngine.UnityEditor
{
    public sealed class DialogueNode : Node
    {
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Content
        {
            get { return this.contentTextField.value; }
            set { this.contentTextField.value = value; }
        }

        public Port InputPort
        {
            get { return this.inputPort; }
        }

        public List<Choice> Choices
        {
            get { return this.choices; }
        }

        public bool IsEntry
        {
            get { return this.isEntry; }
        }

        private int id;

        private TextField contentTextField;

        private Port inputPort;

        private readonly List<Choice> choices = new();

        private bool isEntry;

        public static DialogueNode Instantiate(Vector2 position)
        {
            var node = new DialogueNode();
            node.InitTitle();
            node.InitBody();
            node.InitButton_AddChoice();
            node.InitStyleSheets();
            node.RefreshExpandedState();
            node.SetPosition(new Rect(position, Vector2.zero));
            return node;
        }

        private void InitTitle()
        {
            this.inputPort = InstantiatePort(
                Orientation.Horizontal,
                Direction.Input,
                Port.Capacity.Multi,
                typeof(bool)
            );

            this.inputPort.portColor = Color.white;
            this.inputPort.portName = "";
            this.titleContainer.Insert(0, this.inputPort);
        }

        private void InitBody()
        {
            this.contentTextField = new TextField
            {
                value = "Message",
                multiline = true
            };
            
            this.inputContainer.Insert(0, this.contentTextField);
        }

        private void InitButton_AddChoice()
        {
            var button = new Button
            {
                text = "Add Choice",
                clickable = new Clickable(() => this.AddChoice("Answer"))
            };

            this.extensionContainer.Add(button);
        }

        public void AddChoice(string content, bool refresh = true)
        {
            var port = InstantiatePort(
                Orientation.Horizontal,
                Direction.Output,
                Port.Capacity.Single,
                typeof(bool)
            );
            port.portName = "";
            port.AddToClassList("dialogue_node_port");


            var deleteButton = new Button
            {
                text = "-",
                clickable = new Clickable(() => this.RemoveOutputPort(port))
            };

            var choiceText = new TextField
            {
                value = content
            };

            choiceText.AddToClassList("dialogue_node_choice");

            port.Add(deleteButton);
            port.Add(choiceText);

            this.outputContainer.Add(port);

            var result = new Choice
            {
                port = port,
                textField = choiceText
            };
            this.choices.Add(result);


            if (refresh)
            {
                this.RefreshExpandedState();
            }
        }

        public void RemoveOutputPort(Port outputPort, bool refresh = true)
        {
            this.outputContainer.Remove(outputPort);

            var choice = this.choices.FirstOrDefault(it => it.port == outputPort);
            if (choice.port != null)
            {
                this.choices.Remove(choice);
            }

            if (refresh)
            {
                this.RefreshExpandedState();
            }
        }

        public int IndexOfChoice(Port output)
        {
            for (var i = 0; i < this.choices.Count; i++)
            {
                var choice = this.choices[i];
                if (choice.port == output)
                {
                    return i;
                }
            }

            throw new Exception("Index of port is not found!");
        }


        private void InitStyleSheets()
        {
            this.extensionContainer.AddToClassList("dialogue_node_extension-container");
            this.mainContainer.AddToClassList("dialogue_node_main-container");
            this.contentTextField.AddToClassList("dialogue_node_message");

            this.style.borderTopLeftRadius = 8;
            this.style.borderTopRightRadius = 8;
            this.style.borderBottomLeftRadius = 8;
            this.style.borderBottomRightRadius = 8;
        }

        public void SetAsEntry()
        {
            this.style.backgroundColor = new Color(0.92f, 0.76f, 0f);
            this.isEntry = true;
        }

        public void SetAsNotEntry()
        {
            this.style.backgroundColor = new Color(0.53f, 0.53f, 0.56f);
            this.isEntry = false;
        }

        public struct Choice
        {
            public Port port;
            public TextField textField;
        }
    }
}
#endif