using Elementary;
using GameSystem;

namespace Game.GameEngine
{
    public sealed class InputStateManager : StateMachine<InputStateId>,
        IGameStartElement,
        IGameFinishElement
    {
        void IGameStartElement.StartGame()
        {
            this.Enter();
        }
        
        void IGameFinishElement.FinishGame()
        {
            this.Exit();
        }
    }
}