using System;
using UnityEngine;

namespace Core
{
    public sealed class InputHandler : MonoBehaviour
    {
        private static readonly Vector2 _leftDirection = new (-1f, 0f);
        private static readonly Vector2 _rightDirection = new (1f, 0f);

        public event Action<Vector2> DirectionButtonPressed;
        public event Action ShootingButtonPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootingButtonPressed?.Invoke();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                DirectionButtonPressed?.Invoke(_leftDirection);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                DirectionButtonPressed?.Invoke(_rightDirection);
            }
        }
    }
}