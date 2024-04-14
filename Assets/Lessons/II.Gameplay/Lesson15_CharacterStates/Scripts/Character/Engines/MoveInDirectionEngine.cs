using System;
using Declarative;
using Lessons.Utils;
using UnityEngine;

namespace Lessons.Character.Engines
{
    [Serializable]
    public sealed class MoveInDirectionEngine : IUpdateListener
    {
        private Transform _transform;
        private AtomicVariable<float> _speed;

        private Vector3 _direction;
        
        public void Construct(Transform transform, AtomicVariable<float> speed)
        {
            _transform = transform;
            _speed = speed;
        }
        
        void IUpdateListener.Update(float deltaTime)
        {
            _transform.position += _direction * (_speed * deltaTime);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
    }
}