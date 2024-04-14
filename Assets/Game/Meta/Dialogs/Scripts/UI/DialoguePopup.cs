using Windows;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Meta
{
    public sealed class DialoguePopup : MonoWindow<IDialoguePresentationModel>
    {
        [Space]
        [SerializeField]
        private UnityEvent onFinished;
        
        [Space]
        [SerializeField]
        private TextMeshProUGUI messageText;

        [SerializeField]
        private Image icon;

        [Space]
        [SerializeField]
        private DialogueOptionView[] optionViews;

        private IDialoguePresentationModel presentationModel;
        
        protected override void OnShow(IDialoguePresentationModel presentationModel)
        {
            this.presentationModel = presentationModel;
            this.presentationModel.OnStateChanged += this.OnStateChanged;
            this.presentationModel.OnFinished += this.OnFinished;

            this.icon.sprite = this.presentationModel.Icon;

            this.UpdateMessage();
            this.UpdateOptions();
        }

        protected override void OnHide()
        {
            this.ResetOptions();
        }

        private void OnFinished()
        {
            this.onFinished.Invoke();
        }

        private void OnStateChanged()
        {
            this.UpdateMessage();
            this.UpdateOptions();
        }

        private void UpdateMessage()
        {
            this.messageText.text = this.presentationModel.CurrentMessage;
        }

        private void UpdateOptions()
        {
            var options = this.presentationModel.CurrentOptions;
            var count = options.Length;

            for (var i = 0; i < count; i++)
            {
                var option = options[i];
                var view = this.optionViews[i];
                view.SetVisible(true);
                view.SetText(option.Text);
                view.SetClickAction(option.OnSelected);
            }

            for (int i = count, length = this.optionViews.Length; i < length; i++)
            {
                var view = this.optionViews[i];
                view.SetVisible(false);
                view.ClearClickAction();
            }
        }
        
        private void ResetOptions()
        {
            for (int i = 0, count = this.optionViews.Length; i < count; i++)
            {
                var view = this.optionViews[i];
                view.ClearClickAction();
            }
        }
    }
}