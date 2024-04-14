using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatAction_LookAtTarget : IAction<CombatOperation>
    {
        public ITransformEngine transform;

        public CombatAction_LookAtTarget(ITransformEngine transform)
        {
            this.transform = transform;
        }

        public void Do(CombatOperation operation)
        {
            var targetPosition = operation.targetEntity.Get<IComponent_GetPosition>().Position;
            this.transform.LookAtPosition(targetPosition);
        }
    }
}