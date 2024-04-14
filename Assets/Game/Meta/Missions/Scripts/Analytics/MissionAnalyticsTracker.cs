using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class MissionAnalyticsTracker : 
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private MissionsManager missionsManager;
        
        void IGameReadyElement.ReadyGame()
        {
            this.missionsManager.OnRewardReceived += this.OnReceiveRewardQuest;
        }

        void IGameFinishElement.FinishGame()
        {
            this.missionsManager.OnRewardReceived -= this.OnReceiveRewardQuest;
        }

        private void OnReceiveRewardQuest(Mission mission)
        {
            MissionAnalytics.LogMissionRewardReceived(mission);
        }
    }
}