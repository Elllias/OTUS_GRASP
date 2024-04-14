using System;
using Services;

namespace Game.App
{
    public sealed class GameTask_InitGame : ILoadingTask
    {
        private readonly GameFacade gameFacade;

        [ServiceInject]
        public GameTask_InitGame(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            this.gameFacade.InitGame();
            callback?.Invoke(LoadingResult.Success());
        }
    }
}