using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Requests;

namespace Systems
{
    public class HealthChangeRequestSystem : IEcsRunSystem
    {
        private EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private EcsFilterInject<Inc<HealthChangeRequest>> _filter = EcsWorldsApi.EVENTS;
        private EcsPoolInject<DestroyRequest> _destroyRequestPool = EcsWorldsApi.EVENTS;

        public void Run(IEcsSystems systems)
        {
            var healthChangeRequestPool = _filter.Pools.Inc1;

            foreach (var requestId in _filter.Value)
            {
                var request = healthChangeRequestPool.Get(requestId);
                var healthComponent = request.Target.GetData<HealthComponent>();

                healthComponent.Value += request.Delta;

                if (healthComponent.Value <= 0)
                {
                    var targetEvt = _world.Value.NewEntity();

                    _destroyRequestPool.Value.Add(targetEvt) = new DestroyRequest { EntityId = request.Target.Id };
                }

                var bulletEvt = _world.Value.NewEntity();

                _destroyRequestPool.Value.Add(bulletEvt) = new DestroyRequest { EntityId = request.Target.Id };

                _world.Value.DelEntity(requestId);
            }
        }
    }
}