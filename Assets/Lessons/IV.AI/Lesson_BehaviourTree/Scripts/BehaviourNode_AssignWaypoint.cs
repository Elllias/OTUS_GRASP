using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_AssignWaypoint : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(BlackboardKeys.WAYPOINTS, out Transform[] waypoints) ||
                !this.blackboard.TryGetVariable(BlackboardKeys.WAYPOINT_INDEX, out int waypointIndex))
            {
                this.Return(false);
                return;
            }

            Vector3 targetPosition = waypoints[waypointIndex].position;
            this.blackboard.SetVariable(BlackboardKeys.MOVE_POSITION, targetPosition);
            
            this.Return(true);
        }
    }
}

