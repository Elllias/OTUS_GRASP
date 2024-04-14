using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta
{
    public sealed class UpgradesModule : GameModule
    {
        [SerializeField]
        private UpgradeCatalog catalog;

        [ShowInInspector]
        private UpgradesManager upgradesManager = new();
        
        private Upgrade[] upgrades;

        [Space, ReadOnly, ShowInInspector]
        private UpgradesAnalyticsTracker analyticsTracker = new();

        public override IEnumerable<object> GetServices()
        {
            yield return this.upgradesManager;
        }

        public override IEnumerable<IGameElement> GetElements()
        {
            for (int i = 0, count = this.upgrades.Length; i < count; i++)
            {
                if (this.upgrades[i] is IGameElement element)
                {
                    yield return element;
                }
            }

            yield return this.analyticsTracker;
        }

        public override void ConstructGame(GameContext context)
        {
            this.ConstructUpgrades(context);
            this.ConstructManager(context);
            this.ConstructAnalytics();
        }

        private void ConstructUpgrades(GameContext context)
        {
            GameInjector.InjectAll(context, this.upgrades);
        }

        private void ConstructManager(GameContext context)
        {
            var moneyStorage = context.GetService<MoneyStorage>();
            this.upgradesManager.Construct(moneyStorage);
            this.upgradesManager.Setup(this.upgrades);
        }

        private void ConstructAnalytics()
        {
            this.analyticsTracker.Construct(this.upgradesManager);
        }

        private void Awake()
        {
            this.CreateUpgrades();
        }

        private void CreateUpgrades()
        {
            var configs = this.catalog.GetAllUpgrades();
            var count = configs.Length;
            this.upgrades = new Upgrade[count];

            for (var i = 0; i < count; i++)
            {
                var config = configs[i];
                this.upgrades[i] = config.InstantiateUpgrade();
            }
        }
    }
}