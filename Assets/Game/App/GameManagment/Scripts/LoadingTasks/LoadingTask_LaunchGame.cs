using System;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_LaunchGame : ILoadingTask
    {
        private readonly GameLauncher gameLauncher;

        [ServiceInject]
        public LoadingTask_LaunchGame(GameLauncher gameLauncher)
        {
            this.gameLauncher = gameLauncher;
        }

        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            await this.gameLauncher.LaunchGame();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}