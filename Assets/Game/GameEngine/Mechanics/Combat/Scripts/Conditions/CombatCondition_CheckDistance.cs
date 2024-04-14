using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class CombatCondition_CheckDistance : ICondition<CombatOperation>
    {
        public ITransformEngine myTransform;

        public IValue<float> minDistance;

        public CombatCondition_CheckDistance(ITransformEngine myTransform, IValue<float> minDistance)
        {
            this.myTransform = myTransform;
            this.minDistance = minDistance;
        }

        public CombatCondition_CheckDistance()
        {
        }

        public bool IsTrue(CombatOperation value)
        {
            var targetPosition = value.targetEntity.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }
    }
}