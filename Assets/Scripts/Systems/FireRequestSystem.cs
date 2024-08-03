using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Systems
{
    public class FireRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<FireRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<SpawnCubeRequest> _spawnCubeRequestPool = EcsWorldsApi.EVENTS;
        
        public void Run(IEcsSystems systems)
        {
            var fireRequestPool = _filter.Pools.Inc1;

            foreach (var entity in _filter.Value)
            {
                var fireRequest = fireRequestPool.Get(entity);
                var targetPoint = fireRequest.Target.Value;
                var sourcePoint = fireRequest.Source.Value;

                if (!targetPoint || !sourcePoint)
                {
                    fireRequestPool.Del(entity);
                    return;
                }
                
                var spawnEvent = _world.Value.NewEntity();
                
                _spawnCubeRequestPool.Value.Add(spawnEvent) = new SpawnCubeRequest
                {
                    MoveDirectionComponent = new MoveDirectionComponent { Value = (targetPoint.position - sourcePoint.position).normalized },
                    PositionComponent = new PositionComponent { Value = sourcePoint.position },
                    PrefabComponent = new PrefabComponent { Value = fireRequest.BulletPrefab.Value }
                };
                
                fireRequestPool.Del(entity);
            }
        }
    }
}