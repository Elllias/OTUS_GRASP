using System;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;

namespace Lessons.Meta
{
    public sealed class HarvestResourcesQuest : Quest, IGameConstructElement
    {
        public override event Action<Quest, float> OnProgressChanged;

        [ReadOnly]
        [ShowInInspector]
        [PropertySpace(8)]
        public int CurrentResources { get; set; }

        [ReadOnly]
        [ShowInInspector]
        public int RequiredResources
        {
            get { return this.config.requiredResources; }
        }

        [ReadOnly]
        [ShowInInspector]
        public ResourceType ResourceType
        {
            get { return this.config.resourceType; }
        }

        public override float Progress
        {
            get { return (float) this.CurrentResources / this.RequiredResources; }
        }

        public override string TextProgress
        {
            get { return $"{this.CurrentResources}/{this.RequiredResources}"; }
        }

        private IHeroService heroService;

        private readonly HarvestResourcesQuestConfig config;

        public HarvestResourcesQuest(HarvestResourcesQuestConfig config) : base(config)
        {
            this.config = config;
            this.CurrentResources = 0;
        }

        protected override void OnStart()
        {
            this.heroService.GetHero().Get<IComponent_HarvestResource>().OnHarvestStopped += this.OnHarvestFinished;
        }

        protected override void OnEnd()
        {
            this.heroService.GetHero().Get<IComponent_HarvestResource>().OnHarvestStopped -= this.OnHarvestFinished;
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                this.UpdateQuest(operation);
            }
        }

        private void UpdateQuest(HarvestResourceOperation operation)
        {
            if (operation.resourceType != this.ResourceType)
            {
                return;
            }

            var resourceCount = operation.resourceCount;
            this.CurrentResources = Math.Min(this.CurrentResources + resourceCount, this.RequiredResources);
            this.OnProgressChanged?.Invoke(this, this.Progress);
            this.TryComplete();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.heroService = context.GetService<IHeroService>();
        }
    }
}