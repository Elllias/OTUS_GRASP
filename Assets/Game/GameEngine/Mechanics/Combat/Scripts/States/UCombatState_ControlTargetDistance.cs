using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat State «Control Target Distance»")]
    public sealed class UCombatState_ControlTargetDistance : UState_CheckDistanceToTarget
    {
        [Space, SerializeField]
        public UCombatOperator combatOperator;

        public IComponent_GetPosition targetComponent;

        public override void Enter()
        {
            this.targetComponent = this.combatOperator.Current
                .targetEntity
                .Get<IComponent_GetPosition>();
            base.Enter();
        }

        protected override void OnUpdate(bool distanceReached)
        {
            if (!distanceReached)
            {
                this.combatOperator.Stop();
            }
        }

        protected override Vector3 GetTargetPosition()
        {
            return this.targetComponent.Position;
        }
    }
}