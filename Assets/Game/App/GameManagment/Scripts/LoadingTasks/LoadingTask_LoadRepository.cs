using System;
using Game.UI;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_LoadRepository : ILoadingTask
    {
        private readonly GameRepository repository;

        [ServiceInject]
        public LoadingTask_LoadRepository(GameRepository repository)
        {
            this.repository = repository;
        }

        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            await this.repository.LoadSynchronizedState();
            LoadingScreen.ReportProgress(0.25f);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}