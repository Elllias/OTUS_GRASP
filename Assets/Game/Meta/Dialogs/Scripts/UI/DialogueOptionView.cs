using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Meta
{
    public sealed class DialogueOptionView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI contentText;

        [SerializeField]
        private Button button;

        private UnityAction clickAction;

        public void SetVisible(bool visible)
        {
            this.gameObject.SetActive(visible);
        }

        public void SetText(string text)
        {
            this.contentText.text = text;
        }

        public void SetClickAction(UnityAction action)
        {
            this.ClearClickAction();
            this.clickAction = action;
            this.button.onClick.AddListener(action);
        }

        public void ClearClickAction()
        {
            if (this.clickAction != null)
            {
                this.button.onClick.RemoveListener(this.clickAction);
                this.clickAction = null;
            }
        }
    }
}