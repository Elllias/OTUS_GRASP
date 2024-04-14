using System;

namespace Game.GameEngine.Mechanics
{
    public interface IHitPoints
    {
        event Action OnSetuped;

        event Action<int> OnCurrentPointsChanged;

        event Action<int> OnMaxPointsChanged;

        int Current { get; set; }

        int Max { get; set; }

        void Setup(int current, int max);
    }
}