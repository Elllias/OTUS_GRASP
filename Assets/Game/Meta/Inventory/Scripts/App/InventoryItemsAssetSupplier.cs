using Game.App;
using Game.GameEngine.InventorySystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class InventoryItemsAssetSupplier : IConfigLoader
    {
        private InventoryItemCatalog catalog;

        public InventoryItemConfig GetItem(string name)
        {
            return this.catalog.FindItem(name);
        }

        public InventoryItemConfig[] GetAllItems()
        {
            return this.catalog.GetAllItems();
        }

        void IConfigLoader.LoadConfigs()
        {
            this.catalog = Resources.Load<InventoryItemCatalog>("InventoryItemCatalog");
        }
    }
}