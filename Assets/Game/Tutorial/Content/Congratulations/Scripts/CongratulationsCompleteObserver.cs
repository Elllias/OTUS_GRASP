using Windows;
using Asyncoroutine;
using Game.Localization;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Complete «Congratulations»")]
    public sealed class CongratulationsCompleteObserver : TutorialCompleteObserver
    {
        [SerializeField]
        private AssetReference popupPrefab;

        [SerializeField]
        private CongratulationsConfig config;

        [SerializeField]
        private float showPopupDelay = 0.5f;
        
        private PopupManager popupManager;

        public override void ConstructGame(GameContext context)
        {
            base.ConstructGame(context);
            this.popupManager = context.GetService<PopupManager>();
        }

        protected override void OnTutorialComplete()
        {
            this.ShowPopup();
        }

        private async void ShowPopup()
        {
            await new WaitForSeconds(this.showPopupDelay);

            var handle = this.popupPrefab.LoadAssetAsync<GameObject>();
            await handle.Task;
            var popupPrefab = handle.Result.GetComponent<MonoWindow>();
            
            var title = LocalizationManager.GetCurrentText(this.config.title);
            var description = LocalizationManager.GetCurrentText(this.config.description);
            
            var args = new CongratulationsArgs(title, description);
            this.popupManager.Show(popupPrefab, args);
        }
    }
}