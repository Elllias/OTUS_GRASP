using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Systems
{
    public class LifeTimeSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<DestroyRequest> _destroyRequestPool = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<LifetimeComponent>> _filter;
        private readonly EcsCustomInject<EntityManager> _entityManager;
        
        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;
            var lifetimePool = _filter.Pools.Inc1;
            
            foreach (var lifetimeEntityId in _filter.Value)
            {
                ref var lifetimeComponent = ref lifetimePool.Get(lifetimeEntityId);

                lifetimeComponent.Value -= deltaTime;
                
                if (lifetimeComponent.Value <= 0)
                {
                    var evt = _world.Value.NewEntity();

                    _destroyRequestPool.Value.Add(evt) = new DestroyRequest { EntityId = lifetimeEntityId };
                }
            }
        }
    }
}