using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction Mechanics")]
    public sealed class UMoveInDirectionMechanics : MonoBehaviour
    {
        [SerializeField]
        private UMoveInDirectionMotor moveEngine;

        [SerializeField]
        private UTransformEngine transformEngine;

        [SerializeField]
        private FloatAdapter moveSpeed;

        private void FixedUpdate()
        {
            if (this.moveEngine.IsMoving)
            {
                this.MoveTransform(this.moveEngine.Direction);
            }
        }

        private void MoveTransform(Vector3 direction)
        {
            var velocity = direction * (this.moveSpeed.Current * Time.fixedDeltaTime);
            this.transformEngine.MovePosition(velocity);
            this.transformEngine.LookInDirection(direction);
        }
    }
}