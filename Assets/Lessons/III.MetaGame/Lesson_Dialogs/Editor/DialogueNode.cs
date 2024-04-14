#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueNode : Node
    {
        public string Id
        {
            get { return this.idText.value; }
            set { this.idText.value = value; }
        }

        public string Message
        {
            get { return this.messageText.value; }
            set { this.messageText.value = value; }
        }

        public List<DialogueChoice> Choices
        {
            get { return this.choices; }
        }

        public Port InputPort
        {
            get { return this.inputPort; }
        }

        private readonly List<DialogueChoice> choices = new List<DialogueChoice>();
        private TextField idText;
        private TextField messageText;
        private Port inputPort;

        public DialogueNode()
        {
            this.AddIdText();
            this.AddMessageText();
            this.AddCreateChoiceButton();
            this.AddInputPort();
            this.RefreshExpandedState();
        }

        private void AddCreateChoiceButton()
        {
            Button button = new Button
            {
                text = "Create Choice",
                clickable = new Clickable(this.CreateChoice)
            };

            this.mainContainer.Insert(1, button);
        }

        private void AddInputPort()
        {
            inputPort = Port.Create<Edge>(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            inputPort.portName = "Input Connection";
            inputPort.portColor = Color.white;
            this.inputContainer.Add(inputPort);
        }

        private void AddIdText()
        {
            idText = new TextField
            {
                value = "Dialogue Id",
                multiline = false
            };

            idText.AddToClassList("node_id");
            this.titleContainer.Insert(0, idText);
        }

        private void AddMessageText()
        {
            messageText = new TextField
            {
                value = "Dialogue Message",
                multiline = true
            };
            messageText.AddToClassList("node_message");
            this.extensionContainer.Add(messageText);
        }

        public void CreateChoice()
        {
            this.CreateChoice("Choice Text");
        }

        public void CreateChoice(string option)
        {
            DialogueChoice choice = new DialogueChoice(option);
            choice.OnDeleteEvent += this.DeleteChoice;
            this.choices.Add(choice);
            this.outputContainer.Add(choice);
            this.RefreshExpandedState();
        }

        private void DeleteChoice(DialogueChoice choice)
        {
            choice.OnDeleteEvent -= this.DeleteChoice;
            this.outputContainer.Remove(choice);
            this.choices.Remove(choice);
            this.RefreshExpandedState();
        }
    }
}
#endif