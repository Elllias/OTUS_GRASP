using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class CombatState_ControlTargetDestroy : State
    {
        private IOperator<CombatOperation> combatOperator;

        private object attacker;

        private IComponent_OnDestroyed<DestroyArgs> targetComponent;

        public void ConstructOperator(IOperator<CombatOperation> combatOperator)
        {
            this.combatOperator = combatOperator;
        }

        public void ConstructAttacker(object attacker)
        {
            this.attacker = attacker;
        }

        public override void Enter()
        {
            this.targetComponent = this.combatOperator
                .Current
                .targetEntity
                .Get<IComponent_OnDestroyed<DestroyArgs>>();
            this.targetComponent.OnDestroyed += this.OnTargetDestroyed;
        }

        public override void Exit()
        {
            this.targetComponent.OnDestroyed -= this.OnTargetDestroyed;
        }

        private void OnTargetDestroyed(DestroyArgs destroyArgs)
        {
            if (this.IsDestroyedByAttacker(destroyArgs))
            {
                this.combatOperator.Current.targetDestroyed = true;
            }

            this.combatOperator.Stop();
        }

        private bool IsDestroyedByAttacker(DestroyArgs destroyArgs)
        {
            return destroyArgs.reason == DestroyReason.ATTACKER &&
                   ReferenceEquals(destroyArgs.source, this.attacker);
        }
    }
}