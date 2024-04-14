using UnityEngine;

namespace Lessons.MetaGame.Inventory
{
    [CreateAssetMenu(
        fileName = "InventoryItemConfig",
        menuName = "Lessons/New InventoryItemConfig"
    )]
    public sealed class InventoryItemConfig : ScriptableObject
    {
        [SerializeField]
        public InventoryItem item;
    }
}