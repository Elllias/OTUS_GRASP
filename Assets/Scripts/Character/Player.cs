using System;
using Component;
using Core;
using Interface;
using UnityEngine;

namespace Character
{
    public sealed class Player : MonoBehaviour, IDamageable, IPauseListener, IResumeListener, IStartListener, IFinishListener
    {
        [SerializeField] private InputHandler _inputHandler;

        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootingComponent _shootingComponent;

        public void OnStart()
        {
            OnResume();
        }

        public void OnFinish()
        {
            OnPause();
        }
        
        public void OnResume()
        {
            _inputHandler.DirectionButtonPressed += _moveComponent.Move;
            _inputHandler.ShootingButtonPressed += _shootingComponent.Shoot;
            _hitPointsComponent.HitPointsGone += OnHitPointsGone;
        }

        public void OnPause()
        {
            _inputHandler.DirectionButtonPressed -= _moveComponent.Move;
            _inputHandler.ShootingButtonPressed -= _shootingComponent.Shoot;
            _hitPointsComponent.HitPointsGone -= OnHitPointsGone;
        }

        public void TakeDamage(int damage)
        {
            _hitPointsComponent.TakeDamage(damage);
        }

        private void OnHitPointsGone()
        {
            GameManager.Instance.FinishGame();
        }
    }
}