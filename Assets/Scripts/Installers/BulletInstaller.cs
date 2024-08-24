using System;
using APIs;
using Components;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Views;

namespace Installers
{
    public class BulletInstaller : EntityInstaller
    {
        [SerializeField] private BulletView _bulletView;
        [SerializeField] private float _moveSpeed = 1f;
        [SerializeField] private bool _isRedTeam;
        [SerializeField] private float _lifetime;

        protected override void Install(Entity entity)
        {
            entity.AddData(new PositionComponent { Value = transform.position });
            entity.AddData(new MoveDirectionComponent { Value = transform.forward });
            entity.AddData(new MoveSpeedComponent { Value = _moveSpeed });
            entity.AddData(new TransformComponent { Value = transform });
            entity.AddData(new DamageComponent { Value = 1 });
            entity.AddData(new ViewComponent { Value = _bulletView });
            entity.AddData(new TeamComponent { IsRedTeam = _isRedTeam });
            entity.AddData(new LifetimeComponent { Value = _lifetime });
        }

        protected override void Dispose(Entity entity)
        {
            entity.RemoveData<PositionComponent>();
            entity.RemoveData<MoveDirectionComponent>();
            entity.RemoveData<MoveSpeedComponent>();
            entity.RemoveData<TransformComponent>();
            entity.RemoveData<DamageComponent>();
            entity.RemoveData<ViewComponent>();
            entity.RemoveData<TeamComponent>();
            entity.RemoveData<LifetimeComponent>();
        }
    }
}