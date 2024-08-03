using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Views;

namespace Systems
{
    public class SpawnBulletRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;

        private readonly
            EcsFilterInject<Inc<SpawnCubeRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<DestroyRequest> _destroyRequestPool = EcsWorldsApi.EVENTS;

        private readonly EcsPoolInject<HealthComponent> _healthComponentPool;
        private readonly EcsCustomInject<EntityManager> _entityManager;

        public void Run(IEcsSystems systems)
        {
            var spawnRequestsPool = _filter.Pools.Inc1;
            
            foreach (var evt in _filter.Value)
            {
                var spawnCubeRequest = spawnRequestsPool.Get(evt);
                
                var direction = spawnCubeRequest.MoveDirectionComponent.Value;
                var position = spawnCubeRequest.PositionComponent.Value;
                var prefab = spawnCubeRequest.PrefabComponent.Value;

                var bulletEntity = _entityManager.Value.Create(prefab, position, Quaternion.identity);
                
                bulletEntity.SetData(new MoveDirectionComponent { Value = direction });
                bulletEntity.GetData<BulletViewComponent>().Value.CollisionDetected += OnCollisionDetected;

                _world.Value.DelEntity(evt);
            }
        }

        private void OnCollisionDetected(Entity bullet, Entity target)
        {
            if (!bullet.TryGetData<DamageComponent>(out var damageComponent)
                || !target.HasData<HealthComponent>()) return;

            if (!bullet.TryGetData<TeamComponent>(out var bulletTeam)
                || !target.TryGetData<TeamComponent>(out var targetTeam)) return;

            if (bulletTeam.IsRedTeam == targetTeam.IsRedTeam) return;

            ref var healthComponent = ref _healthComponentPool.Value.Get(target.Id);

            healthComponent.Value -= damageComponent.Value;

            if (healthComponent.Value <= 0)
            {
                var targetEvt = _world.Value.NewEntity();
                
                _destroyRequestPool.Value.Add(targetEvt) = new DestroyRequest { EntityId = target.Id };
            }

            var bulletEvt = _world.Value.NewEntity();
                
            _destroyRequestPool.Value.Add(bulletEvt) = new DestroyRequest { EntityId = bullet.Id };
        }
    }
}