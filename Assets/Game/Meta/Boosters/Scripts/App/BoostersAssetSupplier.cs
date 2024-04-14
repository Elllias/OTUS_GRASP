using Game.App;
using UnityEngine;

namespace Game.Meta
{
    public sealed class BoostersAssetSupplier : IConfigLoader
    {
        private BoosterCatalog catalog;

        public BoosterConfig GetBooster(string id)
        {
            return this.catalog.FindBooster(id);
        }

        public BoosterConfig[] GetAllBoosters()
        {
            return this.catalog.GetAllBoosters();
        }

        void IConfigLoader.LoadConfigs()
        {
            this.catalog = Resources.Load<BoosterCatalog>(BoosterExtensions.BOOSTER_CATALOG_RESOURCE_PATH);
        }
    }
}