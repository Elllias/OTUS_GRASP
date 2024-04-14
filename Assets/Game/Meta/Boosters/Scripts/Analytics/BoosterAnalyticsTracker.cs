using GameSystem;

namespace Game.Meta
{
    public sealed class BoosterAnalyticsTracker : 
        IGameReadyElement,
        IGameFinishElement
    {
        private BoostersManager manager;

        [GameInject]
        public void Construct(BoostersManager manager)
        {
            this.manager = manager;
        }
        
        void IGameReadyElement.ReadyGame()
        {
            this.manager.OnBoosterLaunched += this.OnBoosterLaunched;
        }

        void IGameFinishElement.FinishGame()
        {
            this.manager.OnBoosterLaunched -= this.OnBoosterLaunched;
        }

        private void OnBoosterLaunched(Booster booster)
        {
            BoosterAnalytics.LogBoosterActivated(booster);
        }
    }
}