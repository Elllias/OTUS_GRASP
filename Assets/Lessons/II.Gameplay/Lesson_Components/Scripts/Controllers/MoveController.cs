using UnityEngine;

namespace Lessons.Architecture.Components
{
    public class MoveController : AbstractMoveController
    {
        [SerializeField]
        private Entity unit;

        private IMoveComponent moveComponent;

        private void Awake()
        {
            this.moveComponent = this.unit.Get<IMoveComponent>();
        }

        protected override void Move(Vector3 direction)
        {
            const float speed = 5.0f;
            var velocity = direction * (speed * Time.deltaTime);
            this.moveComponent.Move(velocity);
        }
    }
}