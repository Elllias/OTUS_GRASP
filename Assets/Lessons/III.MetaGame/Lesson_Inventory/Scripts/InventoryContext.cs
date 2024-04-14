using System;
using System.Collections.Generic;
using Game.GameEngine.InventorySystem;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Inventory
{
    public sealed class InventoryContext : MonoBehaviour, IGameConstructElement
    {
        [ShowInInspector]
        private readonly ListInventory inventory = new();

        [Button]
        public void AddItem(InventoryItemConfig config)
        {
            var prefab = config.item;
            var inventoryItem = prefab.Clone();
            this.inventory.AddItem(inventoryItem);
        }

        [Button]
        public void RemoveItem(InventoryItemConfig config)
        {
            this.inventory.RemoveItem(config.item.Name);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            var hero = context.GetService<IHeroService>().GetHero();
            this.inventory.AddObserver(new InventoryEffectsApplier(hero));
        }
    }
}