using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class HarvestResourceAction_HitResource : IAction<HarvestResourceOperation>
    {
        public void Do(HarvestResourceOperation operation)
        {
            operation.targetResource.Get<IComponent_Hit>().Hit();
        }
    }
}