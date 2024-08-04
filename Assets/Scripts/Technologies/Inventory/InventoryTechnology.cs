using Inventory;
using TechTree;

namespace Technologies.Inventory
{
    public sealed class InventoryTechnology : Technology
    {
        private readonly IInventory _inventory;
        private readonly InventoryTechnologyConfig _config;

        public InventoryTechnology(InventoryTechnologyConfig config, IInventory inventory) : base(config)
        {
            _inventory = inventory;
            _config = config;
        }

        protected override void ProcessUnlock()
        {
            _inventory.AddItem(_config.Item);
        }

        protected override void OnInitialize(bool isUnlocked)
        {
            if (isUnlocked)
            {
                _inventory.AddItem(_config.Item);
            }
        }
    }
}