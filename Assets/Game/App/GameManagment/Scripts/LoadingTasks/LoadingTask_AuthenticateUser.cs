using System;
using Game.UI;
using Services;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_AuthenticateUser : ILoadingTask
    {
        private readonly GameClient client;

        [ServiceInject]
        public LoadingTask_AuthenticateUser(GameClient client)
        {
            this.client = client;
        }

        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            var success = await this.client.Authenticate();
            Debug.Log($"AUTH SUCCESS {success}");

            LoadingScreen.ReportProgress(0.2f);
            callback.Invoke(LoadingResult.Success());
        }
    }
}