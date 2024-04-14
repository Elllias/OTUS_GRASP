using Lessons.MetaGame.Inventory;
using UnityEngine;

namespace Lessons.MetaGame.Crafting
{
    [CreateAssetMenu(
        fileName = "InventoryItemReceipt",
        menuName = "Lessons/New InventoryItemReceipt"
    )]
    public sealed class InventoryItemReceipt : ScriptableObject
    {
        public InventoryItemConfig itemResult;
        public InventoryItemIngredient[] ingredients;
    }
}