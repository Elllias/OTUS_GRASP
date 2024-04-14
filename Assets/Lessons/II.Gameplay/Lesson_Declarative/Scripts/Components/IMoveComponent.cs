using Elementary;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    public interface IMoveComponent
    {
        void Move(Vector3 direction);
    }

    public sealed class MoveComponent : IMoveComponent
    {
        private readonly IEmitter<Vector3> moveEvent;

        public MoveComponent(IEmitter<Vector3> moveEvent)
        {
            this.moveEvent = moveEvent;
        }

        public void Move(Vector3 direction)
        {
            this.moveEvent.Call(direction);
        }
    }
}