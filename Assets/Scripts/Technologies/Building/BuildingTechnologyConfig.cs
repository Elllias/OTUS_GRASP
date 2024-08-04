using TechTree;
using UnityEngine;

namespace Technologies.Building
{
    [CreateAssetMenu(
        fileName = "BuildingTechnologyConfig",
        menuName = "Technologies/New BuildingTechnologyConfig"
    )]
    public sealed class BuildingTechnologyConfig : TechnologyConfig<BuildingTechnology>
    {
        [SerializeField] public float Multiplier = 0.5f;
    }
}