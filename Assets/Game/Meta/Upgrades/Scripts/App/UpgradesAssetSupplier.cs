using Game.App;
using UnityEngine;

namespace Game.Meta
{
    public sealed class UpgradesAssetSupplier : IConfigLoader
    {
        private const string UPGRADE_CATALOG = "UpgradeCatalog";

        private UpgradeCatalog catalog;

        public UpgradeConfig GetUpgrade(string id)
        {
            return this.catalog.FindUpgrade(id);
        }

        public UpgradeConfig[] GetAllUpgrades()
        {
            return this.catalog.GetAllUpgrades();
        }

        void IConfigLoader.LoadConfigs()
        {
            this.catalog = Resources.Load<UpgradeCatalog>(UPGRADE_CATALOG);
        }
    }
}