using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Entities;
using Requests;
using UnityEngine;

namespace Views
{
    public class BulletView : View
    {
        private EcsWorld _world;
        private EcsPool<HealthChangeRequest> _healthChangeRequestPool;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Entity>(out var otherEntity)
                || !TryGetComponent<Entity>(out var entity)) return;
            
            if (!entity.TryGetData<DamageComponent>(out var damageComponent)
                || !otherEntity.HasData<HealthComponent>()) return;

            if (!entity.TryGetData<TeamComponent>(out var bulletTeam)
                || !otherEntity.TryGetData<TeamComponent>(out var targetTeam)) return;

            if (bulletTeam.IsRedTeam == targetTeam.IsRedTeam) return;
            
            var evt = _world.NewEntity();

            _healthChangeRequestPool.Add(evt) = new HealthChangeRequest
            {
                Target = otherEntity,
                Delta = damageComponent.Value
            };
        }

        public override void Initialize(EcsWorld eventWorld)
        {
            _world = eventWorld;
            _healthChangeRequestPool = _world.GetPool<HealthChangeRequest>();
        }
    }
}