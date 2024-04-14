using UnityEngine;
using static Lessons.AI.HierarchicalStateMachine.BlackboardKeys;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIPatrolWaypointsState : AIState
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private AIMoveToPositionState moveState;

        [SerializeField]
        private AIPauseState pauseState;

        public override void OnEnter()
        {
            this.blackboard.RemoveVariable(CURRENT_TIME);
            this.moveState.OnEnter();
        }

        public override void OnUpdate()
        {
            if (this.blackboard.HasVariable(CURRENT_TIME))
            {
                this.pauseState.OnUpdate();
            }
            else
            {
                this.Patrol();
            }
        }

        private void Patrol()
        {
            Transform[] waypoints = this.blackboard.GetVariable<Transform[]>(WAYPOINTS);
            int waypointIndex = this.blackboard.GetVariable<int>(WAYPOINT_INDEX);

            Vector3 targetPoint = waypoints[waypointIndex].position;
            this.blackboard.SetVariable(MOVE_POSITION, targetPoint);

            this.moveState.OnUpdate();

            if (this.moveState.IsReached)
            {
                this.SetIdleState();
                this.MoveNextPoint();
            }
        }

        private void SetIdleState()
        {
            var patrolPause = this.blackboard.GetVariable<float>(PATROL_IDLE_TIME);
            this.blackboard.SetVariable(CURRENT_TIME, patrolPause);
        }

        public override void OnExit()
        {
            this.blackboard.RemoveVariable(MOVE_POSITION);
            this.moveState.OnExit();
        }

        private void MoveNextPoint()
        {
            Transform[] waypoints = this.blackboard.GetVariable<Transform[]>(WAYPOINTS);
            int waypointIndex = this.blackboard.GetVariable<int>(WAYPOINT_INDEX);

            waypointIndex++;
            waypointIndex %= waypoints.Length;
            this.blackboard.SetVariable(WAYPOINT_INDEX, waypointIndex);
        }
    }
}