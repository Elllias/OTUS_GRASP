using System;
using System.Threading.Tasks;
using Services;

namespace Game.App
{
    public sealed class GameTask_ReadyGame : ILoadingTask
    {
        private readonly GameFacade gameFacade;

        [ServiceInject]
        public GameTask_ReadyGame(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            this.gameFacade.ReadyGame();
            callback.Invoke(LoadingResult.Success());
        }
    }
}