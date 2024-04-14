using Game.App;

namespace Game.Meta
{
    public static class BoosterAnalytics
    {
        public static void LogBoosterActivated(Booster booster)
        {
            const string eventName = "booster_activated";
            AnalyticsManager.LogEvent(eventName, BoosterId(booster));
        }

        public static AnalyticsParameter BoosterId(Booster booster)
        {
            const string name = "booster_id";
            return new AnalyticsParameter(name, booster.Id);
        }
    }
}