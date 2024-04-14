using System;
using Services;

namespace Game.App
{
    public class GameTask_ConstructGame : ILoadingTask
    {
        private readonly GameFacade gameFacade;
        private readonly IGameLoadListener[] listeners;

        [ServiceInject]
        public GameTask_ConstructGame(GameFacade gameFacade, IGameLoadListener[] listeners)
        {
            this.gameFacade = gameFacade;
            this.listeners = listeners;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            this.gameFacade.ConstructGame();

            foreach (var listener in this.listeners)
            {
                listener.OnLoadGame(this.gameFacade);
            }
            
            callback?.Invoke(LoadingResult.Success());
        }
    }
}