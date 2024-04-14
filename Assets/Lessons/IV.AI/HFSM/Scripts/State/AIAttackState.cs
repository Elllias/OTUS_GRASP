using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIAttackState : AIState
    {
        [SerializeField]
        private Blackboard blackboard;
        
        [Space]
        [SerializeField]
        private AIMoveToPositionState moveState;

        [SerializeField]
        private AICombatState combatState;

        private IComponent_GetPosition targetComponent;

        public override void OnEnter()
        {
            IEntity target = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);
            this.targetComponent = target.Get<IComponent_GetPosition>(); 
        }

        public override void OnUpdate()
        {
            Vector3 targetPosition = this.targetComponent.Position;
            this.blackboard.SetVariable(BlackboardKeys.MOVE_POSITION, targetPosition);
            
            this.moveState.OnUpdate();

            if (this.moveState.IsReached)
            {
                this.combatState.OnEnter();
            }
            else
            {
                this.combatState.OnExit();
            }
        }

        public override void OnExit()
        {
            this.combatState.OnExit();
            this.moveState.OnExit();
        }
    }
}