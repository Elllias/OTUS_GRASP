using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Requests;

namespace Systems
{
    public class UnitDetectionSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<EnemyDetectionRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<FireRequest> _fireRequestPool = EcsWorldsApi.EVENTS;

        private readonly EcsPoolInject<PrefabComponent> _prefabComponentPool;
        private readonly EcsPoolInject<FirePointComponent> _firePointComponentPool;

        public void Run(IEcsSystems systems)
        {
            var detectionRequestPool = _filter.Pools.Inc1;

            foreach (var detectionRequestId in _filter.Value)
            {
                var detectionRequest = detectionRequestPool.Get(detectionRequestId);
                var prefabComponent = _prefabComponentPool.Value.Get(detectionRequest.Source.Id);
                var firePointComponent = _firePointComponentPool.Value.Get(detectionRequest.Source.Id);

                var evt = _world.Value.NewEntity();

                _fireRequestPool.Value.Add(evt) = new FireRequest
                {
                    Target = detectionRequest.Target.GetData<TransformComponent>(),
                    Source = new TransformComponent { Value = firePointComponent.Value },
                    BulletPrefab = prefabComponent
                };

                _world.Value.DelEntity(detectionRequestId);
            }
        }
    }
}