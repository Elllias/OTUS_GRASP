using System;
using System.Collections;
using Bullet;
using Common;
using Component;
using Core;
using Interface;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour, IDamageable, IPauseListener, IResumeListener, IFinishListener
    {
        public event Action<Enemy> Killed;
        
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private ShootingComponent _shootingComponent;
        [SerializeField] private MoveComponent _moveComponent;

        [SerializeField] private float _cooldownTime;

        private Position _attackPosition;
        private Coroutine _shootingCoroutine;

        private bool _isGameStopped;
        
        public void OnPause()
        {
            _isGameStopped = true;
        }
        
        public void OnFinish()
        {
            _isGameStopped = true;
        }
        
        public void OnResume()
        {
            _isGameStopped = false;
        }
        
        public void Initialize(BulletsController bulletsController)
        {
            _shootingComponent.SetBulletController(bulletsController);
            _hitPointsComponent.HitPointsGone += OnHitPointsGone;
            
            _hitPointsComponent.Reset();

            AddCycleListeners();
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
                yield return new WaitWhile(()=>_isGameStopped);
                
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

            RemoveCycleListeners();
            
            Killed?.Invoke(this);
        }
        
        private void AddCycleListeners()
        {
            GameManager.Instance.AddStartListener(_hitPointsComponent);
            
            GameManager.Instance.AddPauseListener(_moveComponent);
            GameManager.Instance.AddResumeListener(_moveComponent);
            GameManager.Instance.AddFinishListener(_moveComponent);
        }
        
        private void RemoveCycleListeners()
        {
            GameManager.Instance.RemoveStartListener(_hitPointsComponent);
            
            GameManager.Instance.RemovePauseListener(_moveComponent);
            GameManager.Instance.RemoveResumeListener(_moveComponent);
            GameManager.Instance.RemoveFinishListener(_moveComponent);
        }
    }
}