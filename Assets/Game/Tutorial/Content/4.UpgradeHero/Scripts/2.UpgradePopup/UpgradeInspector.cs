using System;
using Game.Meta;

namespace Game.Tutorial
{
    public sealed class UpgradeInspector
    {
        private UpgradeHeroConfig config;
        
        private UpgradesManager upgradesManager;

        private Upgrade targetUpgrade;
        
        private Action callback;
        
        public void Construct(UpgradesManager upgradesManager, UpgradeHeroConfig targetConfig)
        {
            this.upgradesManager = upgradesManager;
            this.config = targetConfig;
        }
        
        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.targetUpgrade = this.upgradesManager.GetUpgrade(this.config.upgradeConfig.id);
            this.targetUpgrade.OnLevelUp += this.OnLevelUp;
        }

        private void OnLevelUp(int nextLevel)
        {
            if (nextLevel < this.config.targetLevel)
            {
                return;
            }
            
            this.targetUpgrade.OnLevelUp -= this.OnLevelUp;
            this.targetUpgrade = null;
            this.callback?.Invoke();
        }
    }
}