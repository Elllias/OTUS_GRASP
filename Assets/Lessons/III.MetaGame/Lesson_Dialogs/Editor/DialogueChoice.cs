#if UNITY_EDITOR
using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueChoice : VisualElement
    {
        public event Action<DialogueChoice> OnDeleteEvent;

        public Port Port
        {
            get { return this.port; }
        }

        public string Choice
        {
            get { return this.choiceText.value; }
        }

        private Port port;
        private TextField choiceText;

        public DialogueChoice(string option)
        {
            this.AddPort();
            this.AddDeleteButton();
            this.AddChoiceText(option);
        }

        private void AddDeleteButton()
        {
            Button button = new Button
            {
                text = "X",
                clickable = new Clickable(() => this.OnDeleteEvent?.Invoke(this))
            };
            this.port.Add(button);
        }

        private void AddChoiceText(string option)
        {
            choiceText = new TextField
            {
                value = option,
                multiline = false
            };
            choiceText.AddToClassList("node_choice");
            this.port.Add(choiceText);
        }

        private void AddPort()
        {
            this.port = Port.Create<Edge>(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            this.port.portName = "";
            this.port.portColor = Color.cyan;
            this.Add(this.port);
        }
    }
}
#endif