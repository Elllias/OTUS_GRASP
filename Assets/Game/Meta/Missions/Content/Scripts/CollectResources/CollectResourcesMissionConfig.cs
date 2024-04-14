using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "CollectResourcesMission",
        menuName = MissionExtensions.MENU_PATH + "New CollectResourcesMission"
    )]
    public sealed class CollectResourcesMissionConfig : MissionConfig
    {
        public ResourceType ResourceType
        {
            get { return this.resourceType; }
        }

        public int RequiredResources
        {
            get { return this.requiredResources; }
        }
        
        [Header("Quest")]
        [SerializeField]
        private ResourceType resourceType;

        [SerializeField]
        private int requiredResources;

        public override Mission InstantiateMission()
        {
            return new CollectResourcesMission(config: this);
        }

        public override string Serialize(Mission mission)
        {
            var myMission = (CollectResourcesMission) mission;
            return myMission.CurrentResources.ToString();
        }

        public override void DeserializeTo(string serializedData, Mission mission)
        {
            int.TryParse(serializedData, out var collectedResources);
            var myMission = (CollectResourcesMission) mission;
            myMission.Setup(collectedResources);
        }
    }
}