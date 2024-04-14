using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;
using static Lessons.AI.HierarchicalStateMachine.BlackboardKeys;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIMoveToPositionState : AIState
    {
        [SerializeField]
        private Blackboard blackboard;

        public bool IsReached
        {
            get { return this.isReached; }
        }

        private bool isReached;

        public override void OnUpdate()
        {
            if (!this.blackboard.HasVariable(UNIT) ||
                !this.blackboard.HasVariable(MOVE_POSITION) ||
                !this.blackboard.HasVariable(STOPPING_DISTANCE))
            {
                return;
            }

            IEntity unit = this.blackboard.GetVariable<IEntity>(UNIT);
            Vector3 unitPosition = unit.Get<IComponent_GetPosition>().Position;
            Vector3 targetPosition = this.blackboard.GetVariable<Vector3>(MOVE_POSITION);
            Vector3 distanceVector = targetPosition - unitPosition;

            float stoppingDistance = this.blackboard.GetVariable<float>(STOPPING_DISTANCE);

            this.isReached = distanceVector.magnitude <= stoppingDistance;
            if (!this.isReached)
            {
                Vector3 direction = distanceVector.normalized;
                unit.Get<IComponent_MoveInDirection>().Move(direction);
            }
        }
    }
}