using Game.App;

namespace Game.Meta
{
    public static class UpgradesAnalytics
    {
        public static void LogLevelUpUpgrade(Upgrade upgrade)
        {
            const string eventName = "hero_upgrade_{0}__level_up";
            var name = string.Format(eventName, upgrade.Id);
            AnalyticsManager.LogEvent(name, LevelParameter(upgrade));
        }
        
        public static AnalyticsParameter LevelParameter(Upgrade upgrade)
        {
            const string parameterName = "level";
            return new AnalyticsParameter(parameterName, upgrade.Level);
        }
    }
}