using System;
using APIs;
using Atomic.Elements;
using Atomic.Objects;
using Core;
using UnityEngine;

namespace Character.Components
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField] private Transform _root;
        [SerializeField] private float _speed;
        
        private AtomicVariable<Vector3> _moveDirection;
        
        public void Construct(AtomicEntity entity)
        {
            _moveDirection = entity.Get<AtomicVariable<Vector3>>(CharacterAPI.MOVE_DIRECTION);
        }

        public void Update(float deltaTime)
        {
            if (_moveDirection != null)
                _root.position += _moveDirection.Value * _speed * deltaTime;
        }
    }
}