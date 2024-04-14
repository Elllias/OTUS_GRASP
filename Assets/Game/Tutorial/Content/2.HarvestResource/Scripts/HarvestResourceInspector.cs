using System;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;

namespace Game.Tutorial
{
    public sealed class HarvestResourceInspector
    {
        private HarvestResourceConfig config;

        private IHeroService heroService;

        private Action callback;

        public void Construct(IHeroService heroService, HarvestResourceConfig config)
        {
            this.heroService = heroService;
            this.config = config;
        }

        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.heroService
                .GetHero()
                .Get<IComponent_HarvestResource>()
                .OnHarvestStopped += this.OnHarvestFinished;
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (!operation.isCompleted)
            {
                return;
            }
            
            if (operation.resourceType == this.config.targetResourceType)
            {
                this.CompleteQuest();
            }
        }

        private void CompleteQuest()
        {
            this.heroService
                .GetHero()
                .Get<IComponent_HarvestResource>()
                .OnHarvestStopped -= this.OnHarvestFinished;
            this.callback?.Invoke();
        }
    }
}