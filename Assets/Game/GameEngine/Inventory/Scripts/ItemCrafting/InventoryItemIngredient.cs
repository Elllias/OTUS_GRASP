using System;
using UnityEngine;

namespace Game.GameEngine.InventorySystem
{
    [Serializable]
    public sealed class InventoryItemIngredient
    {
        [SerializeField]
        public InventoryItemConfig itemInfo;

        [SerializeField]
        public int requiredCount;

        public InventoryItemIngredient()
        {
        }

        public InventoryItemIngredient(InventoryItemConfig itemInfo, int requiredCount)
        {
            this.itemInfo = itemInfo;
            this.requiredCount = requiredCount;
        }
    }
}