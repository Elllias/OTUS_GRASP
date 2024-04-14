using Entities;
using GameSystem;
using Lessons.Gameplay.Common;
using UnityEngine;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class VisitResourceController : MonoBehaviour, 
        IGameConstructElement,
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private HeroService heroService;

        private HarvestResourceInteractor harvestInteractor;

        private IComponent_CollisionEvents heroComponent;

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
            this.heroComponent = hero.Get<IComponent_CollisionEvents>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnCollisionEntered += this.OnHeroEntered;
            this.heroComponent.OnCollisionExited += this.OnHeroExited;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnCollisionEntered -= this.OnHeroEntered;
            this.heroComponent.OnCollisionExited -= this.OnHeroExited;
        }

        private void OnHeroEntered(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && this.isResourceCondition.IsTrue(entity))
            {
                if (this.harvestInteractor.CanHarvest(entity))
                {
                    this.harvestInteractor.StartHarvest(entity);
                }
            }
        }

        private void OnHeroExited(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IEntity entity) && this.isResourceCondition.IsTrue(entity))
            {
                if (this.harvestInteractor.IsHarvesting)
                {
                    this.harvestInteractor.CancelHarvest();
                }
            }
        }
    }
}