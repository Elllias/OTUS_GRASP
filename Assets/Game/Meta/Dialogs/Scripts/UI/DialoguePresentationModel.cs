using System;
using Game.GameEngine;
using UnityEngine;
using static Game.Meta.IDialoguePresentationModel;

namespace Game.Meta
{
    public sealed class DialoguePresentationModel : IDialoguePresentationModel
    {
        public event Action OnStateChanged;

        public event Action OnFinished;

        public Sprite Icon
        {
            get { return this.dialogue.Icon; }
        }

        public string CurrentMessage
        {
            get { return this.dialogue.CurrentMessage; }
        }

        public IOption[] CurrentOptions
        {
            get { return this.currentOptions; }
        }

        private readonly Dialogue dialogue;

        private IOption[] currentOptions;

        public DialoguePresentationModel(Dialogue dialogue)
        {
            this.dialogue = dialogue;

            this.UpdateOptions();
        }

        private void UpdateOptions()
        {
            var choices = this.dialogue.CurrentChoices;
            var count = choices.Length;

            this.currentOptions = new IOption[count];
            for (var i = 0; i < count; i++)
            {
                var choice = choices[i];
                var option = new Option(this, choice, i);
                this.currentOptions[i] = option;
            }
        }

        private void SelectChoice(int choiceIndex)
        {
            if (this.dialogue.MoveNext(choiceIndex))
            {
                this.UpdateOptions();
                this.OnStateChanged?.Invoke();
            }
            else
            {
                this.OnFinished?.Invoke();
            }
        }

        private sealed class Option : IOption
        {
            string IOption.Text
            {
                get { return this.choice; }
            }

            private readonly DialoguePresentationModel parent;

            private readonly string choice;
            
            private readonly int index;
            
            public Option(DialoguePresentationModel parent, string choice, int index)
            {
                this.parent = parent;
                this.choice = choice;
                this.index = index;
            }

            void IOption.OnSelected()
            {
                this.parent.SelectChoice(this.index);
            }
        }
    }
}