using System;

namespace Game.GameEngine.GameResources
{
    public interface IComponent_ResourceSourceLimited : IComponent_ResourceSource
    {
        event Action<int> OnLimitChanged;

        int Limit { get; }

        bool IsLimit { get; }

        int AvailableSlots { get; }
        
        void SetLimit(int limit);
    }
}