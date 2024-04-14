using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class LoadingProgressBar : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;

        [SerializeField]
        private Image fill;

        public void SetProgress(float progress)
        {
            this.fill.fillAmount = progress;
            this.text.text = $"{(progress * 100):F0}%";
        }
    }
}