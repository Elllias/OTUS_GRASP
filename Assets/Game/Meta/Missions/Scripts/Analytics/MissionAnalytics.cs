using Game.App;

namespace Game.Meta
{
    public static class MissionAnalytics 
    {
        public static void LogMissionRewardReceived(Mission mission)
        {
            const string eventName = "mission_reward_received";
            AnalyticsManager.LogEvent(eventName, MissionId(mission));
        }

        public static AnalyticsParameter MissionId(Mission mission)
        {
            const string name = "mission_id";
            return new AnalyticsParameter(name, mission.Id);
        }
    }
}