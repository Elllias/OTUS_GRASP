using System;
using Entities;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Lessons.Meta.Quests1
{
    public sealed class HarvestResourcesQuest : Quest, IGameConstructElement
    {
        public override float Progress
        {
            get { return (float) this.currentResources / this.config.requiredResources; }
        }

        private readonly HarvestResourcesQuestConfig config;

        private int currentResources; //Сколько собрали текущих ресурсов:
        
        private IEntity hero;

        public HarvestResourcesQuest(HarvestResourcesQuestConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnStart()
        {
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped += this.OnHarvestFinished;
        }

        protected override void OnStop()
        {
            this.hero.Get<IComponent_HarvestResource>().OnHarvestStopped -= this.OnHarvestFinished;
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (!operation.isCompleted)
            {
                return;
            }

            if (operation.resourceType != this.config.resourceType)
            {
                return;
            }
            
            var collectedResources = operation.resourceCount;
            var requiredResources = this.config.requiredResources;
            this.currentResources = Math.Min(this.currentResources + collectedResources, requiredResources);
            
            this.UpdateProgress();
        }
        
        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.hero = context.GetService<IHeroService>().GetHero();
        }
    }
}