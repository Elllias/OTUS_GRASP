using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class HarvestResourceAction_LookAtResource : IAction<HarvestResourceOperation>
    {
        private readonly ITransformEngine engine;

        public HarvestResourceAction_LookAtResource(ITransformEngine engine)
        {
            this.engine = engine;
        }

        public void Do(HarvestResourceOperation operation)
        {
            var targetPosition = operation.targetResource.Get<IComponent_GetPosition>().Position;
            this.engine.LookAtPosition(targetPosition);
        }
    }
}