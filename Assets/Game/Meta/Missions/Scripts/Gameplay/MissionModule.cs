using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MissionModule : GameModule, IGameInitElement
    {
        [GameService]
        [SerializeField]
        private MissionCatalog catalog;
        
        [GameService, GameElement]
        [Space, ReadOnly, ShowInInspector]
        private MissionsManager manager = new();

        [GameElement]
        [ReadOnly, ShowInInspector]
        private MissionFactory factory = new();

        [ReadOnly, ShowInInspector]
        private MissionSelector selector = new();

        [GameElement]
        [ReadOnly, ShowInInspector]
        private MissionAnalyticsTracker analyticsTracker = new();

        [Title("Initial missions")]
        [SerializeField]
        private MissionConfig easyMission;

        [SerializeField]
        private MissionConfig normalMission;

        [SerializeField]
        private MissionConfig hardMission;
        
        void IGameInitElement.InitGame()
        {
            if (!this.manager.IsMissionExists(MissionDifficulty.EASY))
            {
                this.manager.SetupMission(this.easyMission);
            }

            if (!this.manager.IsMissionExists(MissionDifficulty.NORMAL))
            {
                this.manager.SetupMission(this.normalMission);
            }

            if (!this.manager.IsMissionExists(MissionDifficulty.HARD))
            {
                this.manager.SetupMission(this.hardMission);
            }
        }
    }
}