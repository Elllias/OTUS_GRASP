using System;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public abstract class Upgrade
    {
        public event Action<int> OnLevelUp;

        [ReadOnly]
        [ShowInInspector]
        public string Id
        {
            get { return this.config.id; }
        }

        [ReadOnly]
        [ShowInInspector]
        public int Level
        {
            get { return this.currentLevel; }
        }

        [ReadOnly]
        [ShowInInspector]
        public int MaxLevel
        {
            get { return this.config.maxLevel; }
        }

        public bool IsMaxLevel
        {
            get { return this.currentLevel == this.config.maxLevel; }
        }

        public float Progress
        {
            get { return (float) this.currentLevel / this.config.maxLevel; }
        }

        [ReadOnly]
        [ShowInInspector]
        public UpgradeMetadata Metadata
        {
            get { return this.config.metadata; }
        }

        [ReadOnly]
        [ShowInInspector]
        public abstract string CurrentStats { get; }

        [ReadOnly]
        [ShowInInspector]
        public abstract string NextImprovement { get; }

        [ReadOnly]
        [ShowInInspector]
        public int NextPrice
        {
            get { return this.config.priceTable.GetPrice(this.Level + 1); }
        }

        private readonly UpgradeConfig config;

        private int currentLevel;

        protected Upgrade(UpgradeConfig config)
        {
            this.config = config;
            this.currentLevel = 1;
        }

        public void SetupLevel(int level)
        {
            this.currentLevel = level;
        }

        public void LevelUp()
        {
            if (this.Level >= this.MaxLevel)
            {
                throw new Exception($"Can not increment level for upgrade {this.config.id}!");
            }

            var nextLevel = this.Level + 1;
            this.currentLevel = nextLevel;
            this.LevelUp(nextLevel);
            this.OnLevelUp?.Invoke(nextLevel);
        }

        protected abstract void LevelUp(int level);
    }
}