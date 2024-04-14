using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat State «Control Target Destroy»")]
    public sealed class UCombatState_ControlTargetDestroy : MonoState
    {
        [Space, SerializeField]
        public UCombatOperator combatOperator;

        [SerializeField]
        public Object attacker;

        private IComponent_OnDestroyed<DestroyArgs> targetComponent;

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
            if (this.IsDestroyedByMe(destroyArgs))
            {
                this.combatOperator.Current.targetDestroyed = true;
            }

            this.combatOperator.Stop();
        }

        private bool IsDestroyedByMe(DestroyArgs destroyArgs)
        {
            return destroyArgs.reason == DestroyReason.ATTACKER &&
                   ReferenceEquals(destroyArgs.source, this.attacker);
        }
    }
}