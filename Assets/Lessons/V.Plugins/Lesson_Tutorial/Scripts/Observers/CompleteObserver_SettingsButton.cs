using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Tutorial
{
    public sealed class CompleteObserver_SettingsButton : CompleteObserver
    {
        [SerializeField]
        private Button button;

        protected override void InitGame(GameContext context, bool isCompleted)
        {
            this.button.gameObject.SetActive(isCompleted);
        }

        protected override void OnComplete()
        {
            Debug.Log("TUTORIAL COMPLETE! SHOW SETTINGS BUTTON!");
            this.button.gameObject.SetActive(true);
        }
    }
}