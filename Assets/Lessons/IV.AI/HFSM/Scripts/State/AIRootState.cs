using UnityEngine;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIRootState : AIStateMachine
    {
        [SerializeField]
        private Blackboard blackboard;
        
        [Space]
        [SerializeField]
        private AIPatrolWaypointsState patrolState;

        [SerializeField]
        private AIAttackState attackState;

        public override void OnUpdate()
        {
            if (this.blackboard.HasVariable(BlackboardKeys.ENEMY))
            {
                this.SwitchState(this.attackState);
            }
            else
            {
                this.SwitchState(this.patrolState);
            }
            
            base.OnUpdate();
        }
    }
}