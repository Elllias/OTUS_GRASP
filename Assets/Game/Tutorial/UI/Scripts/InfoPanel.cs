using UnityEngine;
using UnityEngine.UI;

namespace Game.Tutorial.UI
{
    public sealed class InfoPanel : MonoBehaviour
    {
        [SerializeField]
        private Text titleText;

        [SerializeField]
        private Image iconImage;

        public void SetTitle(string title)
        {
            this.titleText.text = title;
        }

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }
    }
}