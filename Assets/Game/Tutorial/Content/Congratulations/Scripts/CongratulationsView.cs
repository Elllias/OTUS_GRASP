using TMPro;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class CongratulationsView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleText;

        [SerializeField]
        private TextMeshProUGUI descriptionText;

        public void Show(object args)
        {
            if (args is CongratulationsArgs infoArgs)
            {
                this.titleText.text = infoArgs.title;
                this.descriptionText.text = infoArgs.description;
            }
        }
    }
}