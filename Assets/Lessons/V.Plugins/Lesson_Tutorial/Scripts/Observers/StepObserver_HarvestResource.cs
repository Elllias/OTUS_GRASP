using Entities;
using GameSystem;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using UnityEngine;

namespace Lessons.Tutorial
{
    public sealed class StepObserver_HarvestResource : StepObserver
    {
        [SerializeField]
        private ResourceType requiredResourceType;

        private IEntity hero;

        protected override void InitGame(GameContext context, bool isStepPassed)
        {
            this.hero = context.GetService<HeroService>().GetHero();
        }

        protected override void OnStartStep()
        {
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped += this.OnHarvestFinished;
        }

        protected override void OnFinishStep()
        {
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped -= this.OnHarvestFinished;
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (!operation.isCompleted)
            {
                return;
            }
            
            if (operation.resourceType == this.requiredResourceType)
            {
                Debug.Log($"RESOURCE COLLECTED {operation.resourceType}");
                this.FinishStepAndMoveNext();
            }
        }
    }
}