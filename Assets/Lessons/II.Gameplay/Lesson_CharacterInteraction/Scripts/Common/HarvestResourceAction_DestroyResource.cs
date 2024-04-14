using Game.GameEngine.Mechanics;
using IHarvestResourceAction = Lessons.Gameplay.Lesson_CharacterInteraction.IHarvestResourceAction;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class HarvestResourceAction_DestroyResource : IHarvestResourceAction
    {
        public void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                var resource = operation.targetResource;
                resource.Get<IComponent_Collect>().Collect();
            }
        }
    }
}