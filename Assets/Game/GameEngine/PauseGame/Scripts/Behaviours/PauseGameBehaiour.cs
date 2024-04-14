using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PauseGameBehaiour : MonoBehaviour, IGameAttachElement
    {
        private GameContext gameContext;

        public void PauseGame()
        {
            if (this.gameContext.CurrentState == GameContext.State.PLAY)
            {
                this.gameContext.PauseGame();
            }
        }

        void IGameAttachElement.AttachGame(GameContext context)
        {
            this.gameContext = context;
        }
    }
}