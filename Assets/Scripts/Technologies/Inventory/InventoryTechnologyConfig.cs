using Sample.Inventory;
using TechTree;
using UnityEngine;

namespace Technologies.Inventory
{
    [CreateAssetMenu(
        fileName = "InventoryTechnologyConfig",
        menuName = "Technologies/New InventoryTechnologyConfig"
    )]
    public sealed class InventoryTechnologyConfig : TechnologyConfig<InventoryTechnology>
    {
        [SerializeField] public ItemConfig Item;
    }
}