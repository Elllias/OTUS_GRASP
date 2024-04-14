using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MoveInDirectionState_Rotation : StateUpdate
    {
        [Space]
        [SerializeField]
        public Mode mode = Mode.INSTANTLY;

        [ShowIf("mode", Mode.SMOOTH)]
        [SerializeField]
        public float rotationSpeed = 45;

        private IMoveInDirectionMotor moveMotor;

        private ITransformEngine transform;

        public void ConstructMotor(IMoveInDirectionMotor moveMotor)
        {
            this.moveMotor = moveMotor;
        }

        public void ConstructTransform(ITransformEngine transform)
        {
            this.transform = transform;
        }

        protected override void Update(float deltaTime)
        {
            if (this.moveMotor.IsMoving)
            {
                this.RotateInDirection(deltaTime);
            }
        }

        private void RotateInDirection(float deltaTime)
        {
            var direction = this.moveMotor.Direction;
            if (this.mode == Mode.INSTANTLY)
            {
                this.transform.LookInDirection(direction);
            }
            else if (this.mode == Mode.SMOOTH)
            {
                this.transform.RotateTowardsInDirection(direction, this.rotationSpeed, deltaTime);
            }
        }

        public enum Mode
        {
            INSTANTLY = 0,
            SMOOTH = 1
        }
    }
}