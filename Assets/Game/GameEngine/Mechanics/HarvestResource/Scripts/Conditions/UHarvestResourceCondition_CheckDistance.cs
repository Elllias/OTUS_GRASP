using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Condition «Check Distance»")]
    public sealed class UHarvestResourceCondition_CheckDistance : UHarvestResourceCondition
    {
        [SerializeField]
        public UTransformEngine myTransform;

        [SerializeField]
        public FloatAdapter minDistance;

        public override bool IsTrue(HarvestResourceOperation value)
        {
            var targetPosition = value.targetResource.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }    
    }
}