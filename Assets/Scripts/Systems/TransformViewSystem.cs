using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Systems
{
    public class TransformViewSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TransformComponent, PositionComponent>> _filter;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                var transform = _filter.Pools.Inc1.Get(entity);
                var position = _filter.Pools.Inc2.Get(entity);

                transform.Value.position = position.Value;
            }
        }
    }
}