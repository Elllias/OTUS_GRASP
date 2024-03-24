using System;
using Component;
using Core;
using Interface;
using UnityEngine;

namespace Character
{
    public sealed class Player : MonoBehaviour, IDamageable
    {
        public event Action Killed;

        [SerializeField] private InputHandler _inputHandler;

        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootingComponent _shootingComponent;

        private void OnEnable()
        {
            _inputHandler.DirectionButtonPressed += _moveComponent.Move;
            _inputHandler.ShootingButtonPressed += _shootingComponent.Shoot;
            _hitPointsComponent.HitPointsGone += OnHitPointsGone;
        }

        private void OnDisable()
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
            Killed?.Invoke();
        }
    }
}