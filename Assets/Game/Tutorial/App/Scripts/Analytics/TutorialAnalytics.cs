using Game.App;
using UnityEngine;

namespace Game.Tutorial.App
{
    public static class TutorialAnalytics
    {
        public static void LogTutorialStarted()
        {
            const string eventName = "tutorial_started";
            LogEventAndCache(eventName);
        }

        public static void LogTutorialCompleted()
        {
            const string eventName = "tutorial_completed";
            LogEventAndCache(eventName);
        }

        public static void LogEventAndCache(string eventName)
        {
            var key = "tutorial_analytics/" + eventName;
            if (PlayerPrefs.HasKey(key))
            {
                return;
            }

            AnalyticsManager.LogEvent(eventName);
            PlayerPrefs.SetInt(key, 1);
        }
    }
}