using Game.GameEngine;
using GameSystem;

namespace Game.Gameplay.Player
{
    public sealed class WorldPlacePopupShower : IGameReadyElement, IGameFinishElement
    {
        private PopupManager popupManager;

        private WorldPlaceVisitInteractor visitInteractor;

        private WorldPlacePopupConfig config;

        private bool enabled = true;
        
        [GameInject]
        public void Construct(
            WorldPlaceVisitInteractor visitInteractor,
            PopupManager popupManager,
            WorldPlacePopupConfig config
        )
        {
            this.visitInteractor = visitInteractor;
            this.popupManager = popupManager;
            this.config = config;
        }

        public void SetEnable(bool enabled)
        {
            this.enabled = enabled;
        }
        
        void IGameReadyElement.ReadyGame()
        {
            this.visitInteractor.OnVisitStarted += this.OnVisitStarted;
        }

        void IGameFinishElement.FinishGame()
        {
            this.visitInteractor.OnVisitStarted -= this.OnVisitStarted;
        }

        private void OnVisitStarted(WorldPlaceType placeType)
        {
            if (!this.enabled)
            {
                return;
            }
            
            if (this.config.FindPopupName(placeType, out var popupName))
            {
                this.popupManager.ShowPopup(popupName);
            }
        }
    }
}