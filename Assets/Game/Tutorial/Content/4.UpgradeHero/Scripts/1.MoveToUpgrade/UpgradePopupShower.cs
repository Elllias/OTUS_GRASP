using System;
using Windows;
using Game.Tutorial.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Tutorial
{
    [Serializable]
    public sealed class UpgradePopupShower
    {
        private PopupManager popupManager;
        
        [SerializeField]
        private AssetReference popupPrefab;

        public void Construct(PopupManager popupManager)
        {
            this.popupManager = popupManager;
        }
        
        public async void ShowPopup()
        {
            var handle = this.popupPrefab.LoadAssetAsync<GameObject>();
            await handle.Task;
            var popup = handle.Result.GetComponent<MonoWindow>();

            this.popupManager.Show(popup, args: null);   
        }
    }
}