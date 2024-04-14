using System;

namespace Lessons.Gameplay.CharacterInteraction
{
    public interface IComponent_HarvestResource
    {
        event Action<HarvestResourceOperation> OnStarted;

        event Action<HarvestResourceOperation> OnFinished;
        
        bool IsHarvesting { get; }

        bool CanStartHarvest(HarvestResourceOperation operation);

        void StartHarvest(HarvestResourceOperation operation);

        void StopHarvest();
    }
}