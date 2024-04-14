using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_OnHitPointsChanged
    {
        event Action<int> OnHitPointsChanged;
    }
}