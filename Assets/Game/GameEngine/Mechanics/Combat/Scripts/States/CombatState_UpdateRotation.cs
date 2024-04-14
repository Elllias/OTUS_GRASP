using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class CombatState_UpdateRotation : StateUpdate
    {
        public Mode mode = Mode.INSTANTLY;

        public float rotationSpeed = 45;

        private IOperator<CombatOperation> combatOperator;

        private ITransformEngine transform;
        
        private IComponent_GetPosition targetComponent;

        public void ConstructOperator(IOperator<CombatOperation> combatOperator)
        {
            this.combatOperator = combatOperator;
        }

        public void ConstructTransform(ITransformEngine transform)
        {
            this.transform = transform;
        }


        public override void Enter()
        {
            this.targetComponent = this.combatOperator
                .Current
                .targetEntity
                .Get<IComponent_GetPosition>();
                
            base.Enter();
        }

        protected override void Update(float deltaTime)
        {
            if (this.combatOperator.IsActive)
            {
                this.RotateInDirection(deltaTime);
            }
        }

        private void RotateInDirection(float deltaTime)
        {
            var targetPosition = this.targetComponent.Position;
            if (this.mode == Mode.INSTANTLY)
            {
                this.transform.LookAtPosition(targetPosition);
            }
            else if (this.mode == Mode.SMOOTH)
            {
                this.transform.RotateTowardsAtPosition(targetPosition, this.rotationSpeed, deltaTime);
            }
        }

        public enum Mode
        {
            INSTANTLY = 0,
            SMOOTH = 1
        }
    }
}