using System;
using System.Collections;
using Game.App;
using Game.Localization;
using Game.Tutorial.UI;
using Windows;
using Asyncoroutine;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Tutorial
{
    [Serializable]
    public sealed class WelcomePopupShower 
    {
        [SerializeField]
        private AssetReference popupPrefab;
        
        [SerializeField]
        private float showPopupDelay = 0.5f;

        private PopupManager popupManager;

        private WelcomeConfig config;

        public void Construct(PopupManager popupManager, WelcomeConfig config)
        {
            this.popupManager = popupManager;
            this.config = config;
        }
    
        public async void ShowPopup(Action callback)
        {
            await new WaitForSeconds(this.showPopupDelay);
            
            var handle = this.popupPrefab.LoadAssetAsync<GameObject>();
            await handle.Task;

            var popupPrefab = handle.Result.GetComponent<MonoWindow>();

            var title = LocalizationManager.GetCurrentText(this.config.title);
            var description = LocalizationManager.GetCurrentText(this.config.description);
            var args = new WelcomeArgs(title, description);
            
            this.popupManager.Show(popupPrefab, args, callback);
        }
    }
}