using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.InventorySystem
{
    [CreateAssetMenu(
        fileName = "InventoryItemReceipt",
        menuName = "GameEngine/Inventory/New InventoryItemReceipt"
    )]
    public sealed class InventoryItemReceipt : SerializedScriptableObject
    {
        [SerializeField]
        public InventoryItemConfig resultInfo;

        [SerializeField]
        public InventoryItemIngredient[] ingredients = new InventoryItemIngredient[0];
    }
}