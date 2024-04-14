using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class CombatState_ControlTargetDistance : State_CheckDistanceToTarget
    {
        private IOperator<CombatOperation> combatEngine;

        private IComponent_GetPosition targetComponent;

        public void ConstructOperator(IOperator<CombatOperation> combatOperator)
        {
            this.combatEngine = combatOperator;
        }

        protected override void OnEnter()
        {
            this.targetComponent = this.combatEngine
                .Current
                .targetEntity
                .Get<IComponent_GetPosition>();
        }
        
        protected override void ProcessDistance(bool distanceReached)
        {
            if (!distanceReached)
            {
                this.combatEngine.Stop();
            }
        }

        protected override Vector3 GetTargetPosition()
        {
            return this.targetComponent.Position;
        }
    }
}