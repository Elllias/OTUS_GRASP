using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class ResumeGameBehaviour : MonoBehaviour, IGameAttachElement
    {
        private GameContext gameContext;

        public void ResumeGame()
        {
            if (this.gameContext.CurrentState == GameContext.State.PAUSE)
            {
                this.gameContext.ResumeGame();
            }
        }

        void IGameAttachElement.AttachGame(GameContext context)
        {
            this.gameContext = context;
        }
    }
}