using System;
using System.Collections;
using Bullet;
using Common;
using Component;
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

        private Position _attackPosition;
        private Coroutine _shootingCoroutine;
        
        public void Initialize(BulletsController bulletsController)
        {
            _shootingComponent.SetBulletController(bulletsController);
            _hitPointsComponent.HitPointsGone += OnHitPointsGone;
            
            _hitPointsComponent.Reset();
        }

        public void SetShootingTarget(Transform target)
        {
            _shootingComponent.SetTargetPoint(target);
        }
        
        public void SmoothlyMoveTo(Position position)
        {
            if (_shootingCoroutine != null)
                StopCoroutine(_shootingCoroutine);

            _attackPosition = position;
            
            _moveComponent.Moved += OnMoved;
            _moveComponent.SmoothlyMoveTo(position.GetPosition());
        }
        
        public void TakeDamage(int damage)
        {
            _hitPointsComponent.TakeDamage(damage);
        }

        private void OnMoved()
        {
            _moveComponent.Moved -= OnMoved;
            
            _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        }

        private IEnumerator ShootingCoroutine()
        {
            while (enabled)
            {
                _shootingComponent.Shoot();
                yield return new WaitForSeconds(_cooldownTime);
            }
        }

        private void OnHitPointsGone()
        {
            _hitPointsComponent.HitPointsGone -= OnHitPointsGone;
            _attackPosition.Release();
            
            if (_shootingCoroutine != null) 
                StopCoroutine(_shootingCoroutine);
            
            Killed?.Invoke(this);
        }
    }
}