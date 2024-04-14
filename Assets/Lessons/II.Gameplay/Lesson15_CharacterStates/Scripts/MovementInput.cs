using System;
using GameSystem;
using UnityEngine;

namespace Lessons
{
    public sealed class MovementInput : MonoBehaviour, IGameUpdateElement
    {
        public event Action<Vector3> MovementDirectionChanged;
        
        private Vector3 _previousMovement;

        void IGameUpdateElement.OnUpdate(float deltaTime)
        {
            var movement = new Vector3();
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                movement.z += 1;
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                movement.z -= 1;
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movement.x += 1;
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movement.x -= 1;
            }

            if (movement != _previousMovement)
            {
                _previousMovement = movement;
                MovementDirectionChanged?.Invoke(movement.normalized);
            }
        }
    }
}