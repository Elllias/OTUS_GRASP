using System;
using Core;
using Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace LevelUtils
{
    public class LevelBackgroundComponent : MonoBehaviour, ITickable
    {
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _endPositionY;
        [SerializeField] private float _movingSpeedY;

        private GameManager _gameManager;
        private LevelBackgroundController _controller;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        public void Awake()
        {
            _controller = new LevelBackgroundController(transform, _startPositionY, _endPositionY, _movingSpeedY, _gameManager);
        }
        
        public void Tick()
        {
            _controller.Tick();
        }
    }
}