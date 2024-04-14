using Game.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta
{
    public sealed class BoosterView : MonoBehaviour
    {
        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private TextMeshProUGUI timerText;

        [SerializeField]
        private TextMeshProUGUI labelText;

        [SerializeField]
        private ProgressBar progressBar;

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }

        public void SetColor(Color color)
        {
            this.progressBar.SetColor(color);
        }

        public void SetLabel(string label)
        {
            this.labelText.text = label;
        }

        public void SetProgress(float progress)
        {
            this.progressBar.SetProgress(progress);
        }
        
        public void SetRemainingText(string text)
        {
            this.timerText.text = text;
        }
    }
}