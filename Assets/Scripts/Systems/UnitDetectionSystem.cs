using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs;
using Components;
using JetBrains.Annotations;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;

namespace Systems
{
    public class UnitDetectionSystem : IEcsInitSystem, IEcsDestroySystem, IEcsRunSystem
    {
        private const float DETECTION_COOLDOWN = 2f;
        
        private readonly EcsWorldInject _world = EcsWorldsApi.EVENTS;
        private readonly EcsFilterInject<Inc<EnemyDetectionRequest>> _filter = EcsWorldsApi.EVENTS;
        private readonly EcsPoolInject<FireRequest> _fireRequestPool = EcsWorldsApi.EVENTS;

        private readonly EcsFilterInject<Inc<UnitViewComponent>> _unitFilter;
        private readonly EcsPoolInject<PrefabComponent> _prefabComponentPool;
        private readonly EcsPoolInject<FirePointComponent> _firePointComponentPool;

        private readonly Dictionary<int, float> _entityCooldownDictionary = new();
        
        public void Init(IEcsSystems systems)
        {
            var unitViewComponentPool = _unitFilter.Pools.Inc1;

            foreach (var unitEntityId in _unitFilter.Value)
            {
                var unitView = unitViewComponentPool.Get(unitEntityId).Value;

                unitView.TriggerStayed += OnTriggerStayed;
            }
        }

        public void Destroy(IEcsSystems systems)
        {
            var unitViewComponentPool = _unitFilter.Pools.Inc1;

            foreach (var unitEntityId in _unitFilter.Value)
            {
                var unitView = unitViewComponentPool.Get(unitEntityId).Value;

                unitView.TriggerStayed -= OnTriggerStayed;
            }
        }

        public void Run(IEcsSystems systems)
        {
            UpdateCooldown(Time.deltaTime);
            
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

        private void OnTriggerStayed(Entity unit, Entity other)
        {
            if (IsEntityCooldownInProgress(unit.Id)) return;
            
            _entityCooldownDictionary[unit.Id] = DETECTION_COOLDOWN;
            
            if (!unit.HasData<UnitViewComponent>()
                      || !other.HasData<UnitViewComponent>()) return;

            if (!unit.TryGetData<TeamComponent>(out var unitTeam)
                || !other.TryGetData<TeamComponent>(out var otherTeam)) return;

            if (unitTeam.IsRedTeam == otherTeam.IsRedTeam) return;

            var evt = _world.Value.NewEntity();

            var detectionRequestPool = _filter.Pools.Inc1;

            detectionRequestPool.Add(evt) = new EnemyDetectionRequest
            {
                Source = unit,
                Target = other
            };
        }

        private void UpdateCooldown(float deltaTime)
        {
            var keys = _entityCooldownDictionary.Keys.Select(x => x).ToList();
            
            foreach (var key in keys)
            {
                _entityCooldownDictionary[key] -= deltaTime;
            }
        }

        private bool IsEntityCooldownInProgress(int entityId)
        {
            if (!_entityCooldownDictionary.TryGetValue(entityId, out var entityCooldown)) return false;

            return entityCooldown > 0;
        }
    }
}