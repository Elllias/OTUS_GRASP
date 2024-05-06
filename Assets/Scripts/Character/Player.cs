using System;
using Bullets;
using Component;
using Component.HitPoints;
using Component.Move;
using Component.Shooting;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace Character
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private HitPointsComponent _hitPointsComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private ShootingComponent _shootingComponent;
        
        private InputHandler _inputHandler;
        private GameManager _gameManager;
        private BulletsController _bulletsController;

        private PlayerController _controller;
        
        [Inject]
        private void Construct(InputHandler inputHandler, GameManager gameManager, BulletsController bulletsController)
        {
            _inputHandler = inputHandler;
            _gameManager = gameManager;
            _bulletsController = bulletsController;
        }
        
        private void Start()
        {
            _controller = new PlayerController(_hitPointsComponent, _moveComponent, _shootingComponent,
                _inputHandler, _gameManager, _bulletsController);
        }
        
        public void TakeDamage(int damage)
        {
            _controller.TakeDamage(damage);
        }
    }
}