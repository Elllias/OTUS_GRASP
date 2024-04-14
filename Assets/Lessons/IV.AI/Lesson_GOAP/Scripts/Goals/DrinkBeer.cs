using AI.GOAP;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class DrinkBeer : Goal
    {
        [SerializeField]
        private int priority = 5;

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