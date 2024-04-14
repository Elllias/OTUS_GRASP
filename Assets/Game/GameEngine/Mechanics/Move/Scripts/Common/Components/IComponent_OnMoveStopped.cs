using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_OnMoveStopped
    {
        event Action OnStopped;
    }
}