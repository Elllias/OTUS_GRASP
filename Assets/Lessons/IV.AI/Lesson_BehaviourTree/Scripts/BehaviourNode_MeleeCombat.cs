using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_MeleeCombat : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        private Coroutine coroutine;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(BlackboardKeys.UNIT, out IEntity unit) ||
                !this.blackboard.TryGetVariable(BlackboardKeys.ENEMY, out IEntity enemy))
            {
                this.Return(false);
                return;
            }
            
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