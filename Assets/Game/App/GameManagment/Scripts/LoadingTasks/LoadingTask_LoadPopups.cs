using System;
using Game.GameEngine;
using Game.UI;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_LoadPopups : ILoadingTask
    {
        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            var popupCatalog = Resources.Load<PopupCatalog>(nameof(PopupCatalog));
            await popupCatalog.LoadAssets();
            LoadingScreen.ReportProgress(0.85f);
            callback.Invoke(LoadingResult.Success());
        }
    }
}