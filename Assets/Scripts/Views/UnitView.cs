using Leopotam.EcsLite;
using Leopotam.EcsLite.Entities;
using Requests;
using UnityEngine;

namespace Views
{
    public class UnitView : View
    {
        [SerializeField] private Entity _entity;

        private EcsWorld _world;
        private EcsPool<ViewTriggerRequest> _viewTriggerRequestPool;
        
        private void OnTriggerStay(Collider other)
        {
            if (!other.TryGetComponent<UnitView>(out var otherEntity)
                || !TryGetComponent<UnitView>(out _)) return;
            
            var evt = _world.NewEntity();

            _viewTriggerRequestPool.Add(evt) = new ViewTriggerRequest
            {
                Source = _entity,
                Target = otherEntity.GetEntity()
            };
        }

        public override void Initialize(EcsWorld eventWorld)
        {
            _world = eventWorld;
            _viewTriggerRequestPool = _world.GetPool<ViewTriggerRequest>();
        }

        private Entity GetEntity()
        {
            return _entity;
        }
    }
}