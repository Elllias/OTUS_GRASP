using JetBrains.Annotations;

namespace Game.App
{
    [UsedImplicitly]
    public sealed class QualitySettingsMediator :
        IAppInitListener,
        IAppStartListener,
        IAppQuitListener
    {
        private const string PREFS_KEY = "QualitySettingsData";

        void IAppInitListener.Init()
        {
            if (ES3.KeyExists(PREFS_KEY))
            {
                var data = ES3.Load<QualitySettingsData>(PREFS_KEY);
                QualitySettingsManager.SetLevel(data.qualityLevel);
            }
        }

        void IAppStartListener.Start()
        {
            QualitySettingsManager.OnLevelChanged += this.SaveSettings;
        }

        void IAppQuitListener.OnQuit()
        {
            QualitySettingsManager.OnLevelChanged -= this.SaveSettings;
        }

        private void SaveSettings(int level)
        {
            var data = new QualitySettingsData
            {
                qualityLevel = level
            };

            ES3.Save(PREFS_KEY, data);
        }
    }
}