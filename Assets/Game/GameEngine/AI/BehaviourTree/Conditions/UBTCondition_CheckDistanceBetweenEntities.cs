using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTAdapter «Abort By Blackboard»")]
    public sealed class UBTCondition_CheckDistanceBetweenEntities : UnityBehaviourCondition, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private float minDistance = 1.0f;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string entity1Key = "Unit";

        [BlackboardKey]
        [SerializeField]
        private string entity2Key = "Target";

        public override bool IsTrue()
        {
            if (!this.Blackboard.TryGetVariable(this.entity1Key, out IEntity unit))
                return false;

            if (!this.Blackboard.TryGetVariable(this.entity2Key, out IEntity target))
                return false;

            return this.IsDistanceReached(unit, target);
        }

        private bool IsDistanceReached(IEntity unit, IEntity target)
        {
            var unitPosition = unit.Get<IComponent_GetPosition>().Position;
            var targetPosition = target.Get<IComponent_GetPosition>().Position;

            var distanceVector = targetPosition - unitPosition;
            return distanceVector.sqrMagnitude <= Mathf.Pow(this.minDistance, 2);
        }
    }
}