using Game.App;
using Game.Meta;

namespace Lessons.Meta
{
    public static class QuestsAnalytics 
    {
        public static void LogQuestStarted(Quest quest)
        {
            const string eventName = "quest_started";
            AnalyticsManager.LogEvent(eventName, QuestId(quest));
        }
        
        public static void LogQuestRewardReceived(Quest quest)
        {
            const string eventName = "quest_reward_received";
            AnalyticsManager.LogEvent(eventName, QuestId(quest));
        }

        public static AnalyticsParameter QuestId(Quest quest)
        {
            const string name = "quest_id";
            return new AnalyticsParameter(name, quest.Id);
        }
    }
}