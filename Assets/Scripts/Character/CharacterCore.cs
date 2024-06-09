using System;
using Atomic.Elements;
using Atomic.Objects;
using Character.Components;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class CharacterCore
    {
        [SerializeField] private MoveComponent _moveComponent;

        public void Construct(AtomicEntity entity)
        {
            _moveComponent.Construct(entity);
        }
        
        public void Update(float deltaTime)
        {
            _moveComponent.Update(deltaTime);
        }
    }
}