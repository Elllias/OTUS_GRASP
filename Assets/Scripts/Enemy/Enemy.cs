using System;
using System.Collections;
using Bullets;
using Common;
using Component;
using Component.HitPoints;
using Component.Move;
using Component.Shooting;
using Core;
using Interface;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public event Action<Enemy> Killed;
        
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private ShootingComponent _shootingComponent;
        [SerializeField] private MoveComponent _moveComponent;

        [SerializeField] private float _cooldownTime;

        private ShootingController _shootingController;
        private HitPointsController _hitPointsController;
        private MoveController _moveController;
        
        private Position _attackPosition;
        private Coroutine _shootingCoroutine;
        
        public void Initialize(BulletsController bulletsController, GameManager gameManager)
        {
            _shootingComponent.Construct(bulletsController);
            _hitPointsComponent.Construct(gameManager);
            _moveComponent.Construct();

            _shootingController = _shootingComponent.GetController();
            
            _hitPointsController = _hitPointsComponent.GetController();
            _hitPointsController.HitPointsGone += OnHitPointsGone;
            _hitPointsController.Reset();
            
            _moveController = _moveComponent.GetController();
        }

        public void SetShootingTarget(Transform target)
        {
            _shootingController.SetTargetPoint(target);
        }
        
        public void SmoothlyMoveTo(Position position)
        {
            if (_shootingCoroutine != null)
                StopCoroutine(_shootingCoroutine);

            _attackPosition = position;
            
            _moveController.Moved += OnMoved;
            _moveController.SmoothlyMoveTo(position.GetPosition());
        }
        
        public void TakeDamage(int damage)
        {
            _hitPointsController.TakeDamage(damage);
        }

        private void OnMoved()
        {
            _moveController.Moved -= OnMoved;
            
            _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        }

        private IEnumerator ShootingCoroutine()
        {
            while (enabled)
            {
                _shootingController.Shoot();
                yield return new WaitForSeconds(_cooldownTime);
            }
        }

        private void OnHitPointsGone()
        {
            _hitPointsController.HitPointsGone -= OnHitPointsGone;
            _attackPosition.Release();
            
            if (_shootingCoroutine != null) 
                StopCoroutine(_shootingCoroutine);
            
            Killed?.Invoke(this);
        }
    }
}