using System;

namespace Game.App
{
    public static class QualitySettingsManager
    {
        public static event Action<int> OnLevelChanged;

        public static int GetLevel()
        {
            return UnityEngine.QualitySettings.GetQualityLevel();
        }

        public static void SetLevel(int level)
        {
            UnityEngine.QualitySettings.SetQualityLevel(level, applyExpensiveChanges: true);
            OnLevelChanged?.Invoke(level);
        }

        public static string[] GetLevelNames()
        {
            return UnityEngine.QualitySettings.names;
        }
    }
}