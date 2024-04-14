using System;
using Sirenix.OdinInspector;

namespace Lessons.MetaGame.Upgrades
{
    public abstract class Upgrade
    {
        [ShowInInspector, ReadOnly]
        public string Id => this.config.id;

        [ShowInInspector, ReadOnly]
        public int Level => this.level;

        [ShowInInspector, ReadOnly]
        public int MaxLevel => this.config.maxLevel;

        [ShowInInspector, ReadOnly]
        public bool IsMaxLevel => this.level >= this.config.maxLevel;

        [ShowInInspector, ReadOnly]
        public int NextPrice => this.config.priceTable.GetPrice(this.level + 1);

        private readonly UpgradeConfig config;
        private int level = 1;

        protected Upgrade(UpgradeConfig config)
        {
            this.config = config;
        }
        
        [Button]
        public void LevelUp()
        {
            if (this.IsMaxLevel)
            {
                throw new Exception("Can't upgrade max level!");
            }

            this.level++;
            this.OnLevelUp(this.level);
        }

        public abstract void OnLevelUp(int i);
    }
}