using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

namespace Component
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public event Action Moved;
        
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed = 0.1f;

        public void Move(Vector2 velocityVector)
        {
            var nextPosition = _rigidbody.position + velocityVector * _speed;
            _rigidbody.MovePosition(nextPosition);
        }

        public void SmoothlyMoveTo(Vector2 targetPoint)
        {
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