using System.Collections;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class MeleeCombatAction : Actor
    {
        [SerializeField]
        private Blackboard blackboard;

        [Space]
        [SerializeField]
        private int cost = 3;

        private Coroutine coroutine;

        public override int EvaluateCost()
        {
            return this.cost;
        }

        public override bool IsValid()
        {
            return this.blackboard.HasVariable(BlackboardKeys.UNIT) &&
                   this.blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        protected override void Play()
        {
            var unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            var enemy = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);

            this.coroutine = this.StartCoroutine(this.Combat(unit, enemy));
        }

        protected override void OnDispose()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
            }
        }

        private IEnumerator Combat(IEntity unit, IEntity enemy)
        {
            var combatComponent = unit.Get<IComponent_MeleeCombat>();
            combatComponent.StopCombat();
            combatComponent.StartCombat(new CombatOperation(enemy));

            var period = new WaitForFixedUpdate();

            while (combatComponent.IsCombat)
            {
                yield return period;
            }

            this.Return(true);
        }
    }
}