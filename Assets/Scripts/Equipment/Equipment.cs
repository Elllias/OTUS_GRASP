using System;
using System.Collections.Generic;
using System.Linq;
using Sample;

namespace Equipment
{
    public sealed class Equipment
    {
        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;
        public event Action<Item> OnItemChanged;

        private Dictionary<EquipmentType, Item> _equippedItems = new();
       
        public void Setup(Dictionary<EquipmentType, Item> equippedItems)
        {
            _equippedItems = equippedItems;
        }

        public Item GetItem(EquipmentType type)
        {
            return _equippedItems[type];
        }

        public bool TryGetItem(EquipmentType type, out Item result)
        {
            if (!_equippedItems.ContainsKey(type))
            {
                result = null;
                return false;
            }
            
            result = _equippedItems[type];
            return true;
        }

        public void RemoveItem(EquipmentType type)
        {
            OnItemRemoved?.Invoke(_equippedItems[type]);
            
            _equippedItems.Remove(type);
        }

        public void AddItem(EquipmentType type, Item item)
        {
            _equippedItems[type] = item;
            
            OnItemAdded?.Invoke(item);
        }

        public void ChangeItem(EquipmentType type, Item item)
        {
            if (!HasItem(type)) return;
            
            _equippedItems[type] = item;
            
            OnItemChanged?.Invoke(item);
        }

        public bool HasItem(EquipmentType type)
        {
            return _equippedItems.ContainsKey(type);
        }

        public Dictionary<EquipmentType, Item> GetItems()
        {
            return _equippedItems;
        }
    }
}