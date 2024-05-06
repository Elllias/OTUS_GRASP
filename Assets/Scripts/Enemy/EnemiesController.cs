using System;
using Bullets;
using Core;
using UnityEngine;
using VContainer;

namespace Enemy
{
    public class EnemiesController : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolTransform;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyPositionsController _enemyPositionsController;

        [SerializeField] private int _initialEnemyCount;
        
        private GameManager _gameManager;
        private BulletsController _bulletsController;
        
        private EnemiesFabric _enemiesFabric;
        
        [Inject]
        private void Construct(GameManager gameManager, BulletsController bulletsController)
        {
            _gameManager = gameManager;
            _bulletsController = bulletsController;
        }
        
        public void Awake()
        {
            _enemiesFabric = new EnemiesFabric(this, _gameManager, _bulletsController);
        }

        public Transform GetTargetTransform()
        {
            return _targetTransform;
        }
        
        public Transform GetWorldTransform()
        {
            return _worldTransform;
        }
        
        public Transform GetPoolTransform()
        {
            return _poolTransform;
        }
        
        public Enemy GetEnemyPrefab()
        {
            return _enemyPrefab;
        }
        
        public EnemyPositionsController GetEnemyPositionsController()
        {
            return _enemyPositionsController;
        }
        
        public int GetInitialEnemyCount()
        {
            return _initialEnemyCount;
        }
    }
}