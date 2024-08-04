using System.Collections.Generic;
using Sample;

namespace Equipment
{
    public class PlayerItemsSystem
    {
        private readonly Equipment _equipment = new();
        private readonly Inventory _inventory = new();

        #region Inventory
        
        public List<Item> GetInventoryItems()
        {
            return _inventory.GetItems();
        }
        
        public void AddItem(Item item)
        {
            _inventory.AddItem(item);
        }
        
        public bool HasItem(string itemName)
        {
            return _inventory.HasItem(itemName);
        }
        
        public void RemoveItem(string itemName)
        {
            _inventory.RemoveItem(itemName);
        }
        
        #endregion
        
        #region Equipment
        
        public Dictionary<EquipmentType, Item> GetEquipmentItems()
        {
            return _equipment.GetItems();
        }
        
        public void EquipItem(EquipmentType type, Item item)
        {
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