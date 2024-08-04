using UnityEngine;

namespace Sample
{
    //Нельзя менять!
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "Sample/New InventoryItemConfig"
    )]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeField]
        public Item item;
    }
}