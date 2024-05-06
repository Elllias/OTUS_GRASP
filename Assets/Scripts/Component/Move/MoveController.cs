using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Component.Move
{
    public class MoveController
    {
        public event Action Moved;
        
        private readonly MoveComponent _moveComponent;
        private readonly Rigidbody2D _rigidbody;
        private readonly float _speed;

        public MoveController(MoveComponent moveComponent, Rigidbody2D rigidbody, float speed)
        {
            _moveComponent = moveComponent;
            _rigidbody = rigidbody;
            _speed = speed;
        }
        
        public void Move(Vector2 velocityVector)
        {
            var nextPosition = _rigidbody.position + velocityVector * _speed;
            _rigidbody.MovePosition(nextPosition);
        }

        public void SmoothlyMoveTo(Vector2 targetPoint)
        {
            _moveComponent.StartCoroutine(SmoothlyMoveToCoroutine(targetPoint));
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