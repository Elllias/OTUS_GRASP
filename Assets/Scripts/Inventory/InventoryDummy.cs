using Sample.Inventory;
using UnityEngine;

namespace Inventory
{
    public sealed class InventoryDummy : IInventory
    {
        public void AddItem(ItemConfig itemConfig)
        {
            Debug.Log($"Added item {itemConfig.Title}");
        }
    }
}