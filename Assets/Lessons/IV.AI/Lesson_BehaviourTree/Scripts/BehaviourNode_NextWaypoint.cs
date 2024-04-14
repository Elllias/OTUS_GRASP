using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_NextWaypoint : BehaviourNode
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

            waypointIndex++;
            waypointIndex %= waypoints.Length;
            
            this.blackboard.SetVariable(BlackboardKeys.WAYPOINT_INDEX, waypointIndex);
            
            this.Return(true);
        }
    }
}

