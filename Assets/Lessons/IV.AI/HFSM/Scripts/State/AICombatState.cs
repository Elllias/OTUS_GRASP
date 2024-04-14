using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AICombatState : AIState
    {
        [SerializeField]
        private Blackboard blackboard;
        
        public override void OnEnter()
        {
            IEntity unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            IEntity enemy = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);

            IComponent_MeleeCombat combatComponent = unit.Get<IComponent_MeleeCombat>();
            if (combatComponent.IsCombat)
            {
                return;
            }
            
            combatComponent.StartCombat(new CombatOperation(enemy));
        }

        public override void OnExit()
        {
            IEntity unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            IComponent_MeleeCombat combatComponent = unit.Get<IComponent_MeleeCombat>();
            if (combatComponent.IsCombat)
            {
                combatComponent.StopCombat();
            }
        }
    }
}