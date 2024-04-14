using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Lessons.Meta.Upgrades
{

    public sealed class VisitResourceObserver : MonoBehaviour, 
        IGameConstructElement,
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private HeroService heroService;

        private HarvestResourceInteractor harvestInteractor;

        private UComponent_ColliderSensor heroComponent;

        [SerializeField]
        private ScriptableEntityCondition isResourceCondition;
        
        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.heroService = context.GetService<HeroService>();
            this.harvestInteractor = context.GetService<HarvestResourceInteractor>();
        }

        void IGameInitElement.InitGame()
        {
            var hero = this.heroService.GetHero();
            this.heroComponent = hero.Get<UComponent_ColliderSensor>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnCollisionsUpdated += this.OnHeroEntered;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnCollisionsUpdated -= this.OnHeroEntered;
        }

        private void OnHeroEntered()
        {
            this.heroComponent.GetCollidersUnsafe(out var buffer, out var size);
            for(var i = 0; i < size; i++)
            {
                var collider = buffer[i];
                if (collider.TryGetComponent(out IEntity entity) && this.isResourceCondition.IsTrue(entity))
                {
                    this.harvestInteractor.TryStartHarvest(entity);
                    return;
                }
            }
        }
    }
}