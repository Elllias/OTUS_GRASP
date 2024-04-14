using Game.App;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MissionsAssetSupplier : IConfigLoader
    {
        private MissionCatalog catalog;

        public MissionConfig GetMission(string id)
        {
            return this.catalog.FindMission(id);
        }

        public MissionConfig[] GetMissions(MissionDifficulty difficulty)
        {
            return this.catalog.FindMissions(difficulty);
        }

        public MissionConfig[] GetAllMissions()
        {
            return this.catalog.GetAllMissions();
        }

        void IConfigLoader.LoadConfigs()
        {
            this.catalog = Resources.Load<MissionCatalog>(MissionExtensions.MISSION_CATALOG_RESOURCE_PATH);
        }
    }
}