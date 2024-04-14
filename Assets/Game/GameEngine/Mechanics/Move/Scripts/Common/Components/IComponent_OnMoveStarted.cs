using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_OnMoveStarted
    {
        event Action OnStarted;
    }
}