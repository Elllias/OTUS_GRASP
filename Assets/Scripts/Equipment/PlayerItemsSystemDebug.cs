using System.Collections.Generic;
using Sample;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Equipment
{
    public class PlayerItemsSystemDebug : MonoBehaviour
    {
        private PlayerItemsSystem _playerItemsSystem;
        
        private void Awake()
        {
            // Можно получить через DI или ServiceLocator
            _playerItemsSystem = new PlayerItemsSystem();
        }
        
        [Button]
        public List<Item> GetItems()
        {
            return _playerItemsSystem.GetInventoryItems();
        }

        [Button]
        public Dictionary<EquipmentType, Item> GetEquippedItems()
        {
            return _playerItemsSystem.GetEquipmentItems();
        }

        [Button]
        public void AddItem(Item item)
        {
            _playerItemsSystem.AddItem(item);
        }

        [Button]
        public void RemoveItem(Item item)
        {
            _playerItemsSystem.RemoveItem(item.Name);
        }

        [Button]
        public bool HasItem(string itemName)
        {
            return _playerItemsSystem.HasItem(itemName);
        }

        [Button]
        public void AddEquippedItem(EquipmentType type, Item item)
        {
            _playerItemsSystem.EquipItem(type, item);
        }

        [Button]
        public void RemoveEquippedItem(EquipmentType type)
        {
            _playerItemsSystem.RemoveEquippedItem(type);
        }

        [Button]
        public bool HasEquippedItem(EquipmentType type)
        {
            return _playerItemsSystem.HasEquippedItem(type);
        }

        [Button]
        public void ChangeEquippedItem(EquipmentType type, Item item)
        {
            _playerItemsSystem.ChangeEquippedItem(type, item);
        }

        [Button]
        public Item GetEquippedItem(EquipmentType type)
        {
            return _playerItemsSystem.GetEquippedItem(type);
        }
    }
}