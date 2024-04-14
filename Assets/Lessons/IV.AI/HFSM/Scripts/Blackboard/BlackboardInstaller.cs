using Entities;
using UnityEngine;
using static Lessons.AI.HierarchicalStateMachine.BlackboardKeys;

namespace Lessons.AI.HierarchicalStateMachine
{
    [RequireComponent(typeof(Blackboard))]
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity unit;
        
        [SerializeField]
        private Transform[] waypoints;

        private void Awake()
        {
            var blackboard = this.GetComponent<Blackboard>();
            blackboard.SetVariable(UNIT, this.unit);
            blackboard.SetVariable(STOPPING_DISTANCE, 0.35f);
            blackboard.SetVariable(WAYPOINTS, this.waypoints);
            blackboard.SetVariable(WAYPOINT_INDEX, 0);
            blackboard.SetVariable(PATROL_IDLE_TIME, 1.0f);
            blackboard.SetVariable(NEAR_ENEMY_DISTANCE, 5.0f);
            blackboard.SetVariable(AT_ENEMY_DISTANCE, 1.0f);
        }
    }
}