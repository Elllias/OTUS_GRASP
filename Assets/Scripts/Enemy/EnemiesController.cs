using System;
using System.Collections;
using Bullet;
using Character;
using Common;
using Interface;
using UnityEngine;

namespace Enemy
{
    public class EnemiesController : MonoBehaviour, IStartListener
    {
        [SerializeField] private BulletsController _bulletController;
        [SerializeField] private Transform _targetTransform;
        
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolTransform;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyPositionsController _enemyPositionsController;
        
        [SerializeField] private int _initialEnemyCount;
        
        private Pool<Enemy> _enemyPool;

        public void OnStart()
        {
            _enemyPool = new Pool<Enemy>(_enemyPrefab, _poolTransform, _worldTransform);

            StartCoroutine(SpawnEnemies());
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
                
            enemy.Initialize(_bulletController);
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