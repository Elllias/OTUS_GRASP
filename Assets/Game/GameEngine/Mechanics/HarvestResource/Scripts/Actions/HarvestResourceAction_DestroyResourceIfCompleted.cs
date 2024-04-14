using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class HarvestResourceAction_DestroyResourceIfCompleted : IAction<HarvestResourceOperation>
    {
        public void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                operation.targetResource.Get<IComponent_Destoy>().Destroy();
            }
        }
    }
}