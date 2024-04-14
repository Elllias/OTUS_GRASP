using Services;

namespace Game.App
{
    public sealed class GameSaver :
        IGameStartListener,
        IGameStopListener
    {
        private const float SAVE_PERIOD_IN_SECONDS = 30;

        private ApplicationManager appManager;

        private GameRepository gameRepository;

        private IGameMediator[] mediators;
        
        private float remainingSeconds;
        
        public bool IsPaused { get; set; }

        [ServiceInject]
        public void Construct(ApplicationManager appManager, GameRepository gameRepository, IGameMediator[] mediators)
        {
            this.appManager = appManager;
            this.gameRepository = gameRepository;
            this.mediators = mediators;
        }

        void IGameStartListener.OnStartGame(GameFacade gameFacade)
        {
            this.remainingSeconds = SAVE_PERIOD_IN_SECONDS;

            this.appManager.OnUpdate += this.OnApplicationUpdate;
            this.appManager.OnPaused += this.OnApplicationPaused;
            this.appManager.OnQuit += this.OnQuitApplication;
        }

        void IGameStopListener.OnStopGame(GameFacade gameFacade)
        {
            this.appManager.OnUpdate -= this.OnApplicationUpdate;
            this.appManager.OnPaused -= this.OnApplicationPaused;
            this.appManager.OnQuit -= this.OnQuitApplication;
        }

        private void OnApplicationUpdate(float deltaTime)
        {
            this.remainingSeconds -= deltaTime;
            if (this.remainingSeconds <= 0.0f)
            {
                this.Save();
            }
        }

        private void OnApplicationPaused()
        {
            this.Save();
        }

        private void OnQuitApplication()
        {
            this.Save();
        }

        public void Save()
        {
            if (this.IsPaused)
            {
                return;
            }
            
            for (int i = 0, count = this.mediators.Length; i < count; i++)
            {
                var mediator = this.mediators[i];
                mediator.SaveData(this.gameRepository);
            }

            this.gameRepository.SaveAllStates();
            this.remainingSeconds = SAVE_PERIOD_IN_SECONDS;
        }
    }
}