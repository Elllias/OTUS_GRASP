using APIs;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Requests;

namespace Systems
{
    public class DestroyRequestSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _eventWorld = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<DestroyRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        private readonly EcsCustomInject<CooldownSystem> _cooldownSystem;

        public void Run(IEcsSystems systems)
        {
            var destroyRequestPool = _filter.Pools.Inc1;

            foreach (var destroyRequestId in _filter.Value)
            {
                var destroyRequest = destroyRequestPool.Get(destroyRequestId);

                _cooldownSystem.Value.Remove(destroyRequest.EntityId);

                _entityManager.Value.Destroy(destroyRequest.EntityId);
                _eventWorld.Value.DelEntity(destroyRequestId);
            }
        }
    }
}