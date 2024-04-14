using Game.App;
using Services;

namespace Game.Meta
{
    public sealed class MisssionsMediator : GameMediator<MissionData[], MissionsManager>
    {
        [ServiceInject]
        private MissionsAssetSupplier assetSupplier;

        protected override void SetupFromData(MissionsManager service, MissionData[] dataSet)
        {
            for (int i = 0, count = dataSet.Length; i < count; i++)
            {
                var data = dataSet[i];
                var config = this.assetSupplier.GetMission(data.id);
                var mission = service.SetupMission(config);
                config.DeserializeTo(data.serializedState, mission);
            }
        }

        protected override void SetupByDefault(MissionsManager service)
        {
            //Do nothing...
        }

        protected override MissionData[] ConvertToData(MissionsManager service)
        {
            var actualMissions = service.GetMissions();
            var count = actualMissions.Length;
            var dataArray = new MissionData[count];

            for (var i = 0; i < count; i++)
            {
                var mission = actualMissions[i];
                var data = this.ConvertToData(mission);
                dataArray[i] = data;
            }

            return dataArray;
        }

        private MissionData ConvertToData(Mission mission)
        {
            var id = mission.Id;
            var config = this.assetSupplier.GetMission(id);
            var data = new MissionData
            {
                id = id,
                serializedState = config.Serialize(mission)
            };

            return data;
        }
    }
}