using Game.App;

namespace Game.Analytics
{
    public static class ApplicationAnalytics
    {
        public static void LogApplicationStarted()
        {
            const string eventName = "app_started";
            AnalyticsManager.LogEvent(eventName);
        }

        public static void LogApplicationPaused()
        {
            const string eventName = "app_paused";
            AnalyticsManager.LogEvent(eventName);
        }

        public static void LogApplicationResumed()
        {
            const string eventName = "app_resumed";
            AnalyticsManager.LogEvent(eventName);
        }

        public static void LogApplicationExited()
        {
            const string eventName = "app_exited";
            AnalyticsManager.LogEvent(eventName);
        }
    }
}