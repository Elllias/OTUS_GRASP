using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat Condition «Check Distance»")]
    public sealed class UCombatCondition_CheckDistance : UCombatCondition
    {
        [SerializeField]
        public UTransformEngine myTransform;

        [SerializeField]
        public FloatAdapter minDistance;

        public override bool IsTrue(CombatOperation value)
        {
            var targetPosition = value.targetEntity.Get<IComponent_GetPosition>().Position;
            return this.myTransform.IsDistanceReached(targetPosition, this.minDistance.Current);
        }
    }
}