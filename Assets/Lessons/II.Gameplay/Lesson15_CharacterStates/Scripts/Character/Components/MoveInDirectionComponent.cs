using Lessons.Utils;
using UnityEngine;

namespace Lessons.Character.Components
{
    public sealed class MoveInDirectionComponent
    {
        private readonly MovementDirectionVariable _movementDirection;
        
        public MoveInDirectionComponent(MovementDirectionVariable movementDirection)
        {
            _movementDirection = movementDirection;
        }
        
        public void MoveInDirection(Vector3 direction)
        {
            _movementDirection.Value = direction;
        }
    }
}