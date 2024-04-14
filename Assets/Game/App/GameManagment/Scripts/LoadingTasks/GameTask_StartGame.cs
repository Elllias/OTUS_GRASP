using System;
using Services;

namespace Game.App
{
    public sealed class GameTask_StartGame : ILoadingTask
    {
        private readonly GameFacade gameFacade;

        private readonly IGameStartListener[] startListeners;
        
        [ServiceInject]
        public GameTask_StartGame(GameFacade gameFacade, IGameStartListener[] startListeners)
        {
            this.gameFacade = gameFacade;
            this.startListeners = startListeners;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            this.gameFacade.StartGame();
            
            for (int i = 0, count = this.startListeners.Length; i < count; i++)
            {
                var listener = this.startListeners[i];
                listener.OnStartGame(this.gameFacade);
            }
            
            callback?.Invoke(LoadingResult.Success());
        }
    }
}