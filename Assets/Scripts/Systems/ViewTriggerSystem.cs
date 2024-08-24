using APIs;
using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Requests;
using UnityEngine;

namespace Systems
{
    public class ViewTriggerSystem : IEcsRunSystem
    {
        private const float DETECTION_COOLDOWN = 2f;

        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<ViewTriggerRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<EnemyDetectionRequest> _enemyDetectionRequestPool = EcsWorldsApi.EVENTS;
        private readonly EcsCustomInject<CooldownSystem> _cooldownSystem;

        public void Run(IEcsSystems systems)
        {
            _cooldownSystem.Value.Update(Time.deltaTime);

            var viewTriggerRequestPool = _filter.Pools.Inc1;

            foreach (var requestId in _filter.Value)
            {
                var request = viewTriggerRequestPool.Get(requestId);
                var unit = request.Source;
                var other = request.Target;

                if (!_cooldownSystem.Value.IsEntityCooldownInProgress(unit.Id))
                {
                    _cooldownSystem.Value.Remove(unit.Id);
                    _cooldownSystem.Value.Add(unit.Id, DETECTION_COOLDOWN);

                    if (unit.HasData<UnitViewComponent>()
                        && other.HasData<UnitViewComponent>()
                        && unit.TryGetData<TeamComponent>(out var unitTeam)
                        && other.TryGetData<TeamComponent>(out var otherTeam)
                        && unitTeam.IsRedTeam != otherTeam.IsRedTeam)
                    {
                        var evt = _world.Value.NewEntity();

                        _enemyDetectionRequestPool.Value.Add(evt) = new EnemyDetectionRequest
                        {
                            Source = unit,
                            Target = other
                        };
                    }
                }

                _world.Value.DelEntity(requestId);
            }
        }
    }
}