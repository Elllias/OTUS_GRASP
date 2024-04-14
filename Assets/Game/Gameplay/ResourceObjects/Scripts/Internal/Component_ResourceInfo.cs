using Game.GameEngine.GameResources;

namespace Game.Gameplay.ResourceObjects
{
    public sealed class Component_ResourceInfo : 
        IComponent_GetResourceType,
        IComponent_GetResourceCount
    {
        public ResourceType Type
        {
            get { return this.info.resourceType; }
        }

        public int Count
        {
            get { return this.info.resourceAmount; }
        }

        private readonly ScriptableResource info;

        public Component_ResourceInfo(ScriptableResource info)
        {
            this.info = info;
        }
    }
}