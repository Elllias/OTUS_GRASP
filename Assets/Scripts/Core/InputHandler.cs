using System;
using Interface;
using UnityEngine;

namespace Core
{
    public sealed class InputHandler : MonoBehaviour, IUpdateListener, IPauseListener, IResumeListener, IFinishListener
    {
        private static readonly Vector2 _leftDirection = new (-1f, 0f);
        private static readonly Vector2 _rightDirection = new (1f, 0f);

        public event Action<Vector2> DirectionButtonPressed;
        public event Action ShootingButtonPressed;
        
        private bool _isGameStopped;

        public void OnFinish()
        {
            _isGameStopped = true;
        }

        public void OnResume()
        {
            _isGameStopped = false;
        }

        public void OnPause()
        {
            _isGameStopped = true;
        }
        
        public void OnUpdate()
        {
            if (_isGameStopped) return;
            
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