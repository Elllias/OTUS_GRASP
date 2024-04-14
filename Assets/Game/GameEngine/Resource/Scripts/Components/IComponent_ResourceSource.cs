using System;

namespace Game.GameEngine.GameResources
{
    public interface IComponent_ResourceSource
    {
        event Action<ResourceType, int> OnResourcesChanged;
        
        int GetResources(ResourceType type);

        void SetupResources(ResourceData[] resources);

        ResourceData[] GetAllResources();

        void PutResources(ResourceType type, int amount);

        void ExtractResources(ResourceType type, int amount);

        int GetSum();

        void Clear();
    }
}