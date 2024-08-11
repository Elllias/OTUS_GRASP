using System.Collections.Generic;
using Sample;

namespace Equipment
{
    public class PlayerItemsSystem
    {
        private readonly Equipment _equipment = new();
        private readonly Inventory _inventory = new();

        #region Inventory
        
        public IReadOnlyList<Item> GetInventoryItems()
        {
            return _inventory.GetItems();
        }
        
        public void AddItem(Item item)
        {
            if (item == null || string.IsNullOrEmpty(item.Name)) return;
            
            _inventory.AddItem(item);
        }
        
        public bool HasItem(string itemName)
        {
            if (string.IsNullOrEmpty(itemName)) return false;
            
            return _inventory.HasItem(itemName);
        }
        
        public void RemoveItem(string itemName)
        {
            if (string.IsNullOrEmpty(itemName)) return;
            
            _inventory.RemoveItem(itemName);
        }
        
        #endregion
        
        #region Equipment
        
        public IReadOnlyDictionary<EquipmentType, Item> GetEquipmentItems()
        {
            return _equipment.GetItems();
        }
        
        public void EquipItem(EquipmentType type, Item item)
        {
            if (item == null || string.IsNullOrEmpty(item.Name)) return;
            
            if (!_inventory.HasItem(item.Name)) return;
            
            _inventory.RemoveItem(item.Name);
            _equipment.AddItem(type, item);
        }
        
        public void RemoveEquippedItem(EquipmentType type)
        {
            var item = _equipment.GetItem(type);
            _equipment.RemoveItem(type);
            _inventory.AddItem(item);
        }
        
        public bool HasEquippedItem(EquipmentType type)
        {
            return _equipment.HasItem(type);
        }
        
        public void ChangeEquippedItem(EquipmentType type, Item item)
        {
            if (item == null) return;
            
            if (!_inventory.HasItem(item.Name)) return;
            
            var currentItem = _equipment.GetItem(type);
            
            _inventory.RemoveItem(item.Name);
            _equipment.ChangeItem(type, item);
            _inventory.AddItem(currentItem);
        }
        
        public Item GetEquippedItem(EquipmentType type)
        {
            return _equipment.GetItem(type);
        }
        
        #endregion
    }
}