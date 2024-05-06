using System;
using System.Collections;
using Bullet;
using Character;
using Common;
using Core;
using Interface;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemiesController : MonoBehaviour, IStartListener, IFinishListener, IResumeListener, IPauseListener
    {
        [SerializeField] private BulletsController _bulletController;
        [SerializeField] private Transform _targetTransform;
        
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private Transform _poolTransform;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyPositionsController _enemyPositionsController;
        
        [SerializeField] private int _initialEnemyCount;
        
        private Pool<Enemy> _enemyPool;

        private bool _isGameStopped;

        public void OnStart()
        {
            _enemyPool = new Pool<Enemy>(_enemyPrefab, _poolTransform, _worldTransform);

            StartCoroutine(SpawnEnemies());
        }
        
        public void OnFinish()
        {
            _isGameStopped = true;
        }

        public void OnResume()
        {
            _isGameStopped = false;
        }

        public void OnPause()
        {
            _isGameStopped = true;
        }

        private IEnumerator SpawnEnemies()
        {
            for (int i = 0; i < _initialEnemyCount; i++)
            {
                yield return new WaitWhile(()=>_isGameStopped);
                
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void SpawnEnemy()
        {
            var spawnPosition = _enemyPositionsController.GetRandomSpawnPosition();
            var enemy = _enemyPool.Get(spawnPosition, Quaternion.identity);
                
            GameManager.Instance.AddPauseListener(enemy);
            GameManager.Instance.AddResumeListener(enemy);
            GameManager.Instance.AddFinishListener(enemy);
            
            enemy.Initialize(_bulletController);
            enemy.SetShootingTarget(_targetTransform.transform);

            enemy.Killed += OnKilled;

            var attackPosition = _enemyPositionsController.GetRandomAttackPosition();
            enemy.SmoothlyMoveTo(attackPosition);
        }

        private void OnKilled(Enemy enemy)
        {
            enemy.Killed -= OnKilled;
            
            GameManager.Instance.RemovePauseListener(enemy);
            GameManager.Instance.RemoveResumeListener(enemy);
            GameManager.Instance.RemoveFinishListener(enemy);
            
            _enemyPool.Release(enemy);
            SpawnEnemy();
        }
    }
}