using System;
using Lessons.Character.Engines;
using Lessons.Utils;
using UnityEngine;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class MoveState : IState
    {
        private MovementDirectionVariable _movementDirection;
        private MoveInDirectionEngine _moveInDirectionEngine;
        private RotateInDirectionEngine _rotateInDirectionEngine;

        public void Construct(MovementDirectionVariable movementDirection, MoveInDirectionEngine moveInDirectionEngine,
            RotateInDirectionEngine rotateInDirectionEngine)
        {
            _movementDirection = movementDirection;
            _moveInDirectionEngine = moveInDirectionEngine;
            _rotateInDirectionEngine = rotateInDirectionEngine;
        }
        
        void IState.Enter()
        {
            _movementDirection.ValueChanged += SetDirection;
            SetDirection(_movementDirection);
        }

        void IState.Exit()
        {
            _movementDirection.ValueChanged -= SetDirection;
            SetDirection(Vector3.zero);
        }

        private void SetDirection(Vector3 direction)
        {
            _moveInDirectionEngine.SetDirection(direction);
            _rotateInDirectionEngine.SetDirection(direction);
        }
    }
}