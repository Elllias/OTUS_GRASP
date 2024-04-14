using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction State «Position»")]
    public sealed class UMoveInDirectionState_Position : MonoState
    {
        [SerializeField]
        private UMoveInDirectionMotor moveEngine;

        [SerializeField]
        private UTransformEngine transformEngine;

        [SerializeField]
        private FloatAdapter speed;

        private void Awake()
        {
            this.enabled = false;
        }

        private void FixedUpdate()
        {
            if (this.moveEngine.IsMoving)
            {
                this.MoveInDirection();
            }
        }

        public override void Enter()
        {
            this.enabled = true;
        }

        public override void Exit()
        {
            this.enabled = false;
        }

        private void MoveInDirection()
        {
            var velocity = this.moveEngine.Direction * (this.speed.Current * Time.fixedDeltaTime);
            this.transformEngine.MovePosition(velocity);
        }
    }
}