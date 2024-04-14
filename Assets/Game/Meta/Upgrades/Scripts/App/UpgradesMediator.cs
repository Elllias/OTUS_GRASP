using Game.App;
using Services;

namespace Game.Meta
{
    public sealed class UpgradesMediator : GameMediator<UpgradeData[], UpgradesManager>
    {
        [ServiceInject]
        private UpgradesAssetSupplier assetSupplier;
        
        protected override void SetupFromData(UpgradesManager service, UpgradeData[] dataSet)
        {
            for (int i = 0, count = dataSet.Length; i < count; i++)
            {
                var data = dataSet[i];
                var upgrade = service.GetUpgrade(data.id);
                upgrade.SetupLevel(data.level);
            }
        }

        protected override void SetupByDefault(UpgradesManager service)
        {
            var configs = this.assetSupplier.GetAllUpgrades();
            var count = configs.Length;

            for (var i = 0; i < count; i++)
            {
                var config = configs[i];
                var upgrade = service.GetUpgrade(config.id);
                upgrade.SetupLevel(config.initialStats.level);
            }
        }

        protected override UpgradeData[] ConvertToData(UpgradesManager service)
        {
            var upgrades = service.GetAllUpgrades();
            var count = upgrades.Length;
            var result = new UpgradeData[count];

            for (var i = 0; i < count; i++)
            {
                var upgrade = upgrades[i];
                var upgradeData = new UpgradeData
                {
                    id = upgrade.Id,
                    level = upgrade.Level
                };
                result[i] = upgradeData;
            }

            return result;
        }
    }
}