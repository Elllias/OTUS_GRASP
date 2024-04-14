using Game.GameEngine.GameResources;
using Game.Gameplay.Player;
using Lessons.Gameplay.Lesson_CharacterInteraction;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class HarvestResourceAction_AddResourcesToStorage : IHarvestResourceAction
    {
        private readonly ResourceStorage storage;

        public HarvestResourceAction_AddResourcesToStorage(ResourceStorage storage)
        {
            this.storage = storage;
        }

        public void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                var resource = operation.targetResource;
                var resourceType = resource.Get<IComponent_GetResourceType>().Type;
                var resourceAmount = resource.Get<IComponent_GetResourceCount>().Count;
                this.storage.AddResource(resourceType, resourceAmount);
            }
        }
    }
}