using System;

namespace Game.GameEngine.GameResources
{
    public interface IComponent_ResourceQuest
    {
        event Action OnCompleted;
        
        ResourceData[] RemainingResources { get; }
        
        ResourceData[] RequiredResources { get; }

        bool IsResourcesEnough { get; }
        
        void PutResources(ResourceType type, int amount);
        
        void SetupResources(ResourceData[] resources);
    }
}