using System.Collections;
using AI.GOAP;
using Entities;
using Game.GameEngine.Entities;
using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class RangeCombatAction : Actor
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
            if (!this.blackboard.HasVariable(BlackboardKeys.ENEMY))
            {
                return false;
            }

            if (!this.blackboard.TryGetVariable(BlackboardKeys.UNIT, out IEntity unit))
            {
                return false;
            }

            return unit.Get<IComponent_RangeCombat>().CanFire();
        }

        protected override void Play()
        {
            var unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            var enemy = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);

            this.coroutine = this.StartCoroutine(this.FireRoutine(unit, enemy));
        }


        protected override void OnDispose()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        private IEnumerator FireRoutine(IEntity unit, IEntity enemy)
        {
            yield return new WaitForSeconds(0.2f);

            var direction = EntityUtils.Direction(unit, enemy);
            var rangeComponent = unit.Get<IComponent_RangeCombat>();
            rangeComponent.Fire(direction);

            yield return new WaitForSeconds(1.25f);

            this.Return(true);
        }
    }
}