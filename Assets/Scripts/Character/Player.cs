using System;
using Component;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace Character
{
    public class Player : MonoBehaviour, IDamageable, IPauseListener, IResumeListener, IStartListener, IFinishListener
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootingComponent _shootingComponent;

        private InputHandler _inputHandler;
        private GameManager _gameManager;

        [Inject]
        private void Construct(InputHandler inputHandler, GameManager gameManager)
        {
            _inputHandler = inputHandler;
            _gameManager = gameManager;
        }

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
            _gameManager.FinishGame();
        }
    }
}