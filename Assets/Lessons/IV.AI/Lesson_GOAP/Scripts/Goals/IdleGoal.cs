using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class IdleGoal : Goal
    {
        [Space]
        [SerializeField]
        private int priority;

        public override bool IsValid()
        {
            return true;
        }

        public override int EvaluatePriority()
        {
            return this.priority;
        }
    }
}