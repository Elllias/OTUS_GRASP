using System;
using System.Collections;
using Bullets;
using Character;
using Common;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace Enemy
{
    public class EnemiesFabric : IStartListener
    {
        private readonly Transform _targetTransform;
        private readonly Transform _worldTransform;
        private readonly Transform _poolTransform;
        private readonly Enemy _enemyPrefab;
        private readonly EnemyPositionsController _enemyPositionsController;
        private readonly int _initialEnemyCount;
        private readonly EnemiesController _enemiesController;
        private readonly GameManager _gameManager;
        private readonly BulletsController _bulletsController;

        private Pool<Enemy> _enemyPool;

        public EnemiesFabric(
            EnemiesController enemiesController,
            GameManager gameManager,
            BulletsController bulletsController)
        {
            _targetTransform = enemiesController.GetTargetTransform();
            _worldTransform = enemiesController.GetWorldTransform();
            _poolTransform = enemiesController.GetPoolTransform();
            _enemyPrefab = enemiesController.GetEnemyPrefab();
            _enemyPositionsController = enemiesController.GetEnemyPositionsController();
            _initialEnemyCount = enemiesController.GetInitialEnemyCount();
            _enemiesController = enemiesController;
            _gameManager = gameManager;
            _bulletsController = bulletsController;
            
            _gameManager.AddStartListener(this);
        }
        
        ~EnemiesFabric()
        {
            _gameManager.RemoveStartListener(this);
        }
        
        public void OnStart()
        {
            _enemyPool = new Pool<Enemy>(_enemyPrefab, _poolTransform, _worldTransform);

            _enemiesController.StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            for (int i = 0; i < _initialEnemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = _enemyPositionsController.GetRandomSpawnPosition();
            var enemy = _enemyPool.Get(spawnPosition, Quaternion.identity);
                
            enemy.Initialize(_bulletsController, _gameManager);
            enemy.SetShootingTarget(_targetTransform.transform);

            enemy.Killed += OnKilled;

            var attackPosition = _enemyPositionsController.GetRandomAttackPosition();
            enemy.SmoothlyMoveTo(attackPosition);
        }

        private void OnKilled(Enemy enemy)
        {
            enemy.Killed -= OnKilled;
            
            _enemyPool.Release(enemy);
            SpawnEnemy();
        }
    }
}