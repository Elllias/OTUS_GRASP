using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_OnMaxHitPointsChanged
    {
        event Action<int> OnMaxHitPointsChanged;
    }
}