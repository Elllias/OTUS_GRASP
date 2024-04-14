using System;
using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class CombatGoal : Goal, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private int priority = 20;

        [SerializeField]
        private int minPriority = 10;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.targetKey);
        }

        public override int EvaluatePriority()
        {
            var enemy = this.Blackboard.GetVariable<IEntity>(this.targetKey);
            var current = enemy.Get<IComponent_GetHitPoints>().HitPoints;
            var max = enemy.Get<IComponent_GetMaxHitPoints>().MaxHitPoints;

            var percent = 1 - (float) current / max;
            var priority = Mathf.RoundToInt(this.priority * percent);
            return this.minPriority + priority;
        }
    }
}