using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class HarvestResourceCondition_CheckDistance : ICondition<HarvestResourceOperation>
    {
        public ITransformEngine myTransform;

        public IValue<float> minDistance;

        public HarvestResourceCondition_CheckDistance(ITransformEngine myTransform, IValue<float> minDistance)
        {
            this.myTransform = myTransform;
            this.minDistance = minDistance;
        }

        public HarvestResourceCondition_CheckDistance()
        {
        }

        public bool IsTrue(HarvestResourceOperation value)
        {
            var targetPosition = value.targetResource.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }
    }
}