using System;
using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Views
{
    public class BulletView : MonoBehaviour
    {
        public event Action<Entity, Entity> CollisionDetected;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Entity>(out var otherEntity)
                || !TryGetComponent<Entity>(out var entity)) return;
            
            CollisionDetected?.Invoke(entity, otherEntity);
        }
    }
}