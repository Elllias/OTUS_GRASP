using System;
using Services;
using SqliteModule;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_UpdateDatabase : ILoadingTask
    {
        private readonly SqliteDatabaseUpdater updater;

        [ServiceInject]
        public LoadingTask_UpdateDatabase(SqliteDatabaseUpdater updater)
        {
            this.updater = updater;
        }

        public async void Do(Action<LoadingResult> callback)
        {
            var checkForUpdates = await this.updater.CheckForUpdates();

            LoadingResult result;
            if (checkForUpdates.isSuccessful)
            {
                result = LoadingResult.Success();
            }
            else
            {
                result = LoadingResult.Fail(checkForUpdates.error);
            }

            callback?.Invoke(result);
        }
    }
}