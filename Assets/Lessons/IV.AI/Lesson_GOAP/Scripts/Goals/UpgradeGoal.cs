using AI.Blackboards;
using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class UpgradeGoal : Goal, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private int priority;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string blacksmithKey;
        
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.blacksmithKey);
        }

        public override int EvaluatePriority()
        {
            return this.priority;
        }
    }
}