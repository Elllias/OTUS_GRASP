using TMPro;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class WelcomeView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleText;

        [SerializeField]
        private TextMeshProUGUI descriptionText;

        public void Show(object args)
        {
            if (args is WelcomeArgs infoArgs)
            {
                this.titleText.text = infoArgs.title;
                this.descriptionText.text = infoArgs.description;
            }
        }
    }
}