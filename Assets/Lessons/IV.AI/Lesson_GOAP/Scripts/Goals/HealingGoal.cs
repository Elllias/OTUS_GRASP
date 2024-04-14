using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HealingGoal : Goal, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private int maxPriority = 20;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string healingPointKey;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.TryGetVariable(this.healingPointKey, out HealingPoint point) &&
                   point.isActive;
        }

        public override int EvaluatePriority()
        {
            var unit = this.Blackboard.GetVariable<IEntity>(this.unitKey);
            var current = unit.Get<IComponent_GetHitPoints>().HitPoints;
            var max = unit.Get<IComponent_GetMaxHitPoints>().MaxHitPoints;
           
            var percent = 1 - (float) current / max;
            var priority = Mathf.RoundToInt(this.maxPriority * percent);
            return priority;
        }
    }
}