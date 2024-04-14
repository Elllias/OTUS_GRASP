using AI.GOAP;
using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class DestoyEnemyGoal : Goal
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private int priority = 10;
        
        public override bool IsValid()
        {
            return this.blackboard.HasVariable(BlackboardKeys.UNIT) &&
                   this.blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        public override int EvaluatePriority()
        {
            return this.priority;
        }
    }
}