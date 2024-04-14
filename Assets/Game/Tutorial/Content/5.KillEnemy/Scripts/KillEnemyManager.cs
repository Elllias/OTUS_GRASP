using System;
using System.Collections;
using System.Threading.Tasks;
using Entities;
using GameSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Tutorial
{
    [Serializable]
    public sealed class KillEnemyManager
    {
        private GameContext gameContext;
        
        [SerializeField]
        private AssetReference enemyPrefab;
        
        [SerializeField]
        private Transform worldTransform;

        [SerializeField]
        private Transform spawnPoint;
        
        [SerializeField]
        private float destroyDelay = 1.25f;

        public void Construct(GameContext context)
        {
            this.gameContext = context;
        }

        public async Task<MonoEntity> SpawnEnemy()
        {
            var handle = this.enemyPrefab.LoadAssetAsync<GameObject>();
            await handle.Task;
            var enemyPrefab = handle.Result.GetComponent<MonoEntity>();

            var enemy = GameObject.Instantiate(
                enemyPrefab,
                this.spawnPoint.position,
                this.spawnPoint.rotation,
                this.worldTransform
            );

            var gameElement = enemy.GetComponent<IGameElement>();
            this.gameContext.RegisterElement(gameElement);

            return enemy;
        }

        public IEnumerator DestroyEnemy(MonoEntity entity)
        {
            var gameElement = entity.GetComponent<IGameElement>();
            this.gameContext.UnregisterElement(gameElement);
            
            yield return new WaitForSecondsRealtime(this.destroyDelay);
            GameObject.Destroy(entity.gameObject);
        }
    }
}