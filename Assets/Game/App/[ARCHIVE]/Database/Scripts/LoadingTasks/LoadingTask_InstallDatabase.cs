using System;
using Services;
using SqliteModule;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_InstallDatabase : ILoadingTask
    {
        private readonly SqliteDatabaseInstaller installer;

        [ServiceInject]
        public LoadingTask_InstallDatabase(SqliteDatabaseInstaller installer)
        {
            this.installer = installer;
        }

        public void Do(Action<LoadingResult> callback)
        {
            this.installer.Install();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}