using System;
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Lessons.Meta.Upgrades
{
    [Serializable]
    public sealed class HarvestResourceInteractor : MonoBehaviour, IGameInitElement
    {
        private HeroService heroService;

        [SerializeField]
        private float delay = 0.15f;

        private IComponent_HarvestResource heroComponent;

        private Coroutine delayCoroutine;

        [GameInject]
        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        public void TryStartHarvest(IEntity resourceObject)
        {
            if (this.heroComponent.IsHarvesting)
            {
                return;
            }

            if (this.delayCoroutine == null)
            {
                this.delayCoroutine = this.StartCoroutine(this.HarvestRoutine(resourceObject));
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