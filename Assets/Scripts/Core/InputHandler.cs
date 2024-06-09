using System;
using APIs;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Core
{
    public class InputHandler
    {
        private readonly AtomicVariable<Vector3> _moveDirection;

        public InputHandler(IAtomicEntity entity)
        {
            _moveDirection = entity.Get<AtomicVariable<Vector3>>(CharacterAPI.MOVE_DIRECTION);
        }

        public void Update()
        {
            _moveDirection.Value = Vector3.zero;
            
            if (Input.GetKey(KeyCode.UpArrow))
                _moveDirection.Value = Vector3.forward;
            
            if (Input.GetKey(KeyCode.DownArrow))
                _moveDirection.Value = Vector3.back;
            
            if (Input.GetKey(KeyCode.LeftArrow))
                _moveDirection.Value = Vector3.left;
            
            if (Input.GetKey(KeyCode.RightArrow))
                _moveDirection.Value = Vector3.right;
        }
    }
}