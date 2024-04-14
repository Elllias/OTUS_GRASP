using GameSystem;

namespace Game.GameEngine
{
    public sealed class PopupInputController : 
        IGameStartElement,
        IGameFinishElement
    {
        private PopupManager popupManager;

        private InputStateManager inputManager;
        
        public void Construct(PopupManager popupManager, InputStateManager inputManager)
        {
            this.popupManager = popupManager;
            this.inputManager = inputManager;
        }

        void IGameStartElement.StartGame()
        {
            this.popupManager.OnPopupShown += this.OnPopupShown;
            this.popupManager.OnPopupHidden += this.OnPopupHidden;
        }

        void IGameFinishElement.FinishGame()
        {
            this.popupManager.OnPopupShown -= this.OnPopupShown;
            this.popupManager.OnPopupHidden -= this.OnPopupHidden;
        }

        private void OnPopupShown(PopupName _)
        {
            this.inputManager.SwitchState(InputStateId.LOCK);
        }

        private void OnPopupHidden(PopupName _)
        {
            if (!this.popupManager.HasActivePopups)
            {
                this.inputManager.SwitchState(InputStateId.BASE);
            }
        }
    }
}