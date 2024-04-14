using Game.Tutorial.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    public sealed class UpgradePopupController : TutorialStepController
    {
        [SerializeField]
        private GameObject upgradeCursor;

        [SerializeField]
        private GameObject closeCursor;

        [SerializeField]
        private GameObject fading;

        [SerializeField]
        private Button closeButton;
        
        protected override void OnStart()
        {
            this.upgradeCursor.SetActive(true);
            this.closeCursor.SetActive(false);
            this.closeButton.gameObject.SetActive(false);
        }

        protected override void OnStop()
        {
            this.closeCursor.SetActive(true);
            this.upgradeCursor.SetActive(false);

            this.closeButton.gameObject.SetActive(true);
            this.closeButton.onClick.AddListener(this.OnCloseClicked);
            this.fading.transform.SetAsLastSibling();
        }

        private void OnCloseClicked()
        {
            this.closeButton.onClick.RemoveListener(this.OnCloseClicked);
            this.NotifyAboutMoveNext();
        }
    }
}