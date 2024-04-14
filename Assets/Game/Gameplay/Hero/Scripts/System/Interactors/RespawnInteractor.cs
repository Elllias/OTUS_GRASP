using System;
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class RespawnInteractor : IGameInitElement
    {
        private HeroService heroService;

        private MonoBehaviour monoContext;
        
        private IEntity hero;

        [SerializeField]
        private float delay = 0.25f;

        private Transform spawnPoint;

        private Coroutine respawnCoroutine;

        [GameInject]
        public void Construct(HeroService heroService, MonoBehaviour monoContext)
        {
            this.heroService = heroService;
            this.monoContext = monoContext;
        }
        
        void IGameInitElement.InitGame()
        {
            this.hero = this.heroService.GetHero();
            this.ResetPosition();
            this.ResetRotation();
        }

        public void SetupSpawnPoint(Transform spawnPoint)
        {
            this.spawnPoint = spawnPoint;
        }

        public void StartRespawn()
        {
            if (this.respawnCoroutine == null)
            {
                this.respawnCoroutine = this.monoContext.StartCoroutine(this.RespawnRoutine());
            }
        }

        private IEnumerator RespawnRoutine()
        {
            yield return new WaitForSeconds(this.delay);
            this.ResetPosition();
            this.ResetRotation();
            this.InvokeRespawn();

            this.respawnCoroutine = null;
        }


        private void ResetPosition()
        {
            this.hero
                .Get<IComponent_SetPosition>()
                .SetPosition(this.spawnPoint.position);
        }

        private void ResetRotation()
        {
            this.hero
                .Get<IComponent_SetRotation>()
                .SetRotation(this.spawnPoint.rotation);
        }

        private void InvokeRespawn()
        {
            this.hero
                .Get<IComponent_Respawn>()
                .Respawn();
        }
    }
}