using System;
using Components;
using Leopotam.EcsLite.Entities;
using UnityEngine;
using Views;

namespace Installers
{
    public class UnitInstaller : EntityInstaller
    {
        [SerializeField] private UnitView _unitView;
        
        [Header("Moving Data")]
        [SerializeField] private float _moveSpeed = 0.5f;

        [Header("Shooting Data")] 
        [SerializeField] private Entity _bulletPrefab;
        [SerializeField] private Transform _shootingPoint;
        
        [Header("Health Data")]
        [SerializeField] private int _health = 3;

        [Header("Collision Data")]
        [SerializeField] private Collider _collider;
        [SerializeField] private bool _isRedTeam;

        protected override void Install(Entity entity)
        {
            entity.AddData(new PositionComponent { Value = transform.position });
            entity.AddData(new TransformComponent { Value = transform });
            entity.AddData(new MoveSpeedComponent { Value = _moveSpeed });
            entity.AddData(new MoveDirectionComponent { Value = transform.forward });
            entity.AddData(new HealthComponent { Value = _health });
            entity.AddData(new PrefabComponent { Value = _bulletPrefab });
            entity.AddData(new FirePointComponent { Value = _shootingPoint });
            entity.AddData(new UnitViewComponent { Value = _unitView });
            entity.AddData(new TeamComponent { IsRedTeam = _isRedTeam });
        }

        protected override void Dispose(Entity entity)
        {
            entity.RemoveData<PositionComponent>();
            entity.RemoveData<TransformComponent>();
            entity.RemoveData<MoveSpeedComponent>();
            entity.RemoveData<MoveDirectionComponent>();
            entity.RemoveData<HealthComponent>();
            entity.RemoveData<PrefabComponent>();
            entity.RemoveData<FirePointComponent>();
            entity.RemoveData<UnitViewComponent>();
            entity.RemoveData<TeamComponent>();
        }
    }
}