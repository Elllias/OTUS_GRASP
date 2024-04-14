using System;
using Lessons.MetaGame.Inventory;

namespace Lessons.MetaGame.Crafting
{
    [Serializable]
    public struct InventoryItemIngredient
    {
        public InventoryItemConfig item;
        public int amount;
    }
}