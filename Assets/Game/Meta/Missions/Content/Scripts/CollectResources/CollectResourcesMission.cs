using System;
using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class CollectResourcesMission : Mission
    {
        public override event Action<Mission> OnProgressChanged;

        [ReadOnly]
        [ShowInInspector]
        [PropertySpace(8)]
        public int CurrentResources { get; private set; }

        [ReadOnly]
        [ShowInInspector]
        public int RequiredResources
        {
            get { return this.config.RequiredResources; }
        }

        [ReadOnly]
        [ShowInInspector]
        public ResourceType ResourceType
        {
            get { return this.config.ResourceType; }
        }

        public override float NormalizedProgress
        {
            get { return (float) this.CurrentResources / this.RequiredResources; }
        }

        public override string TextProgress
        {
            get { return $"{this.CurrentResources}/{this.RequiredResources}"; }
        }

        private readonly CollectResourcesMissionConfig config;

        [GameInject]
        private ResourceStorage resourceStorage;

        public CollectResourcesMission(CollectResourcesMissionConfig config) : base(config)
        {
            this.config = config;
            this.CurrentResources = 0;
        }

        public void Setup(int currentResources)
        {
            this.CurrentResources = Math.Min(currentResources, this.RequiredResources);
        }

        protected override void OnStart()
        {
            this.resourceStorage.OnResourceAdded += this.OnResourcesAdded;
        }

        protected override void OnStop()
        {
            this.resourceStorage.OnResourceAdded -= this.OnResourcesAdded;
        }

        private void OnResourcesAdded(ResourceType resourceType, int income)
        {
            if (resourceType != this.config.ResourceType)
            {
                return;
            }

            this.CurrentResources = Math.Min(this.CurrentResources + income, this.RequiredResources);
            this.OnProgressChanged?.Invoke(this);
            this.TryComplete();
        }
    }
}