using UnityEngine;

namespace Sample.Inventory
{
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "Inventory/New ItemConfig"
    )]
    public sealed class ItemConfig : ScriptableObject
    {
        [field: SerializeField]
        public string Title;
    }
}