using TechTree;
using Weapons;

namespace Technologies.Building
{
    public sealed class BuildingTechnology : Technology
    {
        private readonly IBuildingSystem _buildingSystem;
        private readonly BuildingTechnologyConfig _config;

        public BuildingTechnology(BuildingTechnologyConfig config, IBuildingSystem buildingSystem) : base(config)
        {
            _buildingSystem = buildingSystem;
            _config = config;
        }

        protected override void OnInitialize(bool isUnlocked)
        {
            if (isUnlocked)
            {
                _buildingSystem.CostMultiplier = _config.Multiplier;
            }
        }

        protected override void ProcessUnlock()
        {
            _buildingSystem.CostMultiplier = _config.Multiplier;
        }
    }
}