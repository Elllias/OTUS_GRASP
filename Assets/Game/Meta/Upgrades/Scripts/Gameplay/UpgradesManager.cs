using System;
using System.Collections.Generic;
using System.Linq;
using Game.Gameplay.Player;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    [Serializable]
    public sealed class UpgradesManager
    {
        public event Action<Upgrade> OnLevelUp;
        
        [ReadOnly, ShowInInspector]
        private Dictionary<string, Upgrade> upgrades = new();

        private MoneyStorage moneyStorage;

        public void Construct(MoneyStorage moneyStorage)
        {
            this.moneyStorage = moneyStorage;
        }

        public void Setup(Upgrade[] upgrades)
        {
            this.upgrades = new Dictionary<string, Upgrade>();
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var upgrade = upgrades[i];
                this.upgrades[upgrade.Id] = upgrade;
            }
        }

        public Upgrade GetUpgrade(string id)
        {
            return this.upgrades[id];
        }

        public Upgrade[] GetAllUpgrades()
        {
            return this.upgrades.Values.ToArray<Upgrade>();
        }

        public bool CanLevelUp(Upgrade upgrade)
        {
            if (upgrade.IsMaxLevel)
            {
                return false;
            }

            var price = upgrade.NextPrice;
            return this.moneyStorage.CanSpendMoney(price);
        }

        public void LevelUp(Upgrade upgrade)
        {
            if (!this.CanLevelUp(upgrade))
            {
                throw new Exception($"Can not level up {upgrade.Id}");
            }

            var price = upgrade.NextPrice;
            this.moneyStorage.SpendMoney(price);

            upgrade.LevelUp();
            this.OnLevelUp?.Invoke(upgrade);
        }

        [Title("Methods")]
        [Button]
        public bool CanLevelUp(string id)
        {
            var upgrade = this.upgrades[id];
            return this.CanLevelUp(upgrade);
        }

        [Button]
        public void LevelUp(string id)
        {
            var upgrade = this.upgrades[id];
            this.LevelUp(upgrade);
        }
    }
}