using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Requests;
using UnityEngine;

namespace Systems
{
    public class SpawnBulletRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;

        private readonly EcsFilterInject<Inc<SpawnCubeRequest>> _filter = EcsWorldsApi.EVENTS;
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
                bulletEntity.GetData<ViewComponent>().Value.Initialize(_world.Value);

                _world.Value.DelEntity(evt);
            }
        }
    }
}