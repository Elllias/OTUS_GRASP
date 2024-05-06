using System;
using System.Collections;
using Interface;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

namespace Component
{
    public sealed class MoveComponent : MonoBehaviour, IPauseListener, IResumeListener, IFinishListener
    {
        public event Action Moved;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _initialSpeed = 0.1f;

        private float _speed;
        
        public void OnPause()
        {
            _speed = 0;
        }

        public void OnResume()
        {
            _speed = _initialSpeed;
        }

        public void OnFinish()
        {
            _speed = 0;
        }
        
        public void Move(Vector2 velocityVector)
        {
            _speed = _initialSpeed;
            
            var nextPosition = _rigidbody.position + velocityVector * _speed;
            _rigidbody.MovePosition(nextPosition);
        }

        public void SmoothlyMoveTo(Vector2 targetPoint)
        {
            _speed = _initialSpeed;
            
            StartCoroutine(SmoothlyMoveToCoroutine(targetPoint));
        }

        private IEnumerator SmoothlyMoveToCoroutine(Vector2 targetPoint)
        {
            while ((_rigidbody.position - targetPoint).magnitude >= 0.05)
            {
                _rigidbody.position = Vector2.Lerp(_rigidbody.position, targetPoint, Time.deltaTime * _speed);
                yield return new FixedUpdate();
            }

            _rigidbody.position = targetPoint;
            
            Moved?.Invoke();
        }
    }
}