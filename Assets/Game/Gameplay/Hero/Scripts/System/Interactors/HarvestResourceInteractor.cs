using System;
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HarvestResourceInteractor : IGameInitElement
    {
        private HeroService heroService;

        private MonoBehaviour monoContext;

        [SerializeField]
        private float delay = 0.15f;

        private IComponent_HarvestResource heroComponent;

        private Coroutine delayCoroutine;

        [GameInject]
        public void Construct(HeroService heroService, MonoBehaviour monoContext)
        {
            this.heroService = heroService;
            this.monoContext = monoContext;
        }

        public void TryStartHarvest(IEntity resourceObject)
        {
            if (this.heroComponent.IsHarvesting)
            {
                return;
            }

            if (this.delayCoroutine == null)
            {
                this.delayCoroutine = this.monoContext.StartCoroutine(this.HarvestRoutine(resourceObject));
            }
        }

        private IEnumerator HarvestRoutine(IEntity resourceObject)
        {
            yield return new WaitForSeconds(this.delay);

            var operation = new HarvestResourceOperation(resourceObject);
            if (this.heroComponent.CanStartHarvest(operation))
            {
                this.heroComponent.StartHarvest(operation);
            }

            this.delayCoroutine = null;
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_HarvestResource>();
        }
    }
}