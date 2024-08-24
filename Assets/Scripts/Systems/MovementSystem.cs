using Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveDirectionComponent, MoveSpeedComponent, PositionComponent>> _filter;

        public void Run(IEcsSystems systems)
        {
            var deltaTime = Time.deltaTime;

            var moveDirectionPool = _filter.Pools.Inc1;
            var moveSpeedPool = _filter.Pools.Inc2;
            var positionPool = _filter.Pools.Inc3;

            foreach (var entity in _filter.Value)
            {
                ref var moveDirection = ref moveDirectionPool.Get(entity);
                ref var moveSpeed = ref moveSpeedPool.Get(entity);
                ref var position = ref positionPool.Get(entity);

                position.Value += moveDirection.Value * (moveSpeed.Value * deltaTime);
            }
        }
    }
}