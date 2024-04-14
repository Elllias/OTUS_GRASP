using AI.Blackboards;
using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class PatrolGoal : Goal, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private int priority;

        [BlackboardKey]
        [SerializeField]
        private string waypointsKey;

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.waypointsKey);
        }

        public override int EvaluatePriority()
        {
            return this.priority;
        }
    }
}