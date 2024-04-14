using System;
using Game.UI;
using Services;

namespace Game.App
{
    public sealed class GameTask_SetupData : ILoadingTask
    {
        private readonly GameRepository repository;
        
        private readonly IGameMediator[] mediators;

        [ServiceInject]
        public GameTask_SetupData(GameRepository repository, IGameMediator[] mediators)
        {
            this.repository = repository;
            this.mediators = mediators;
        }

        void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            for (int i = 0, count = this.mediators.Length; i < count; i++)
            {
                var mediator = this.mediators[i];
                mediator.SetupData(this.repository);
            }
            
            LoadingScreen.ReportProgress(0.9f);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}