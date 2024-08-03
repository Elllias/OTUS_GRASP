using System;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Views
{
    public class UnitView : MonoBehaviour
    {
        public event Action<Entity, Entity> TriggerStayed;

        [SerializeField] private Entity _entity;
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<UnitView>(out var otherEntity)
                || !TryGetComponent<UnitView>(out _)) return;
                
            TriggerStayed?.Invoke(_entity, otherEntity.GetEntity());
        }

        private Entity GetEntity()
        {
            return _entity;
        }
    }
}