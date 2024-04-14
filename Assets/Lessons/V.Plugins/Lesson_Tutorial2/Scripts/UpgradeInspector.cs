using System;
using Game.Meta;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    public sealed class UpgradeInspector
    {
        private UpgradeHeroStepConfig config;

        private UpgradesManager upgradesManager;
        
        private Upgrade targetUpgrade;

        private Action callback;

        public void Construct(UpgradeHeroStepConfig config, UpgradesManager upgradesManager)
        {
            this.config = config;
            this.upgradesManager = upgradesManager;
        }
        
        public void InspectUpgrade(Action onFinished)
        {
            this.callback = onFinished;
            
            var targetUpgradeId = config.targetUpgrade.id;
            this.targetUpgrade = this.upgradesManager.GetUpgrade(targetUpgradeId);
            this.targetUpgrade.OnLevelUp += this.OnLevelUp;
        }

        private void OnLevelUp(int newLevel)
        {
            if (newLevel < this.config.targetLevel)
            {
                return;
            }

            this.targetUpgrade.OnLevelUp -= this.OnLevelUp;
            this.callback?.Invoke();
        }
    }
}