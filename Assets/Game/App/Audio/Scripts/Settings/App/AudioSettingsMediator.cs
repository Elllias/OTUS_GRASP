using JetBrains.Annotations;

namespace Game.App
{
    [UsedImplicitly]
    public sealed class AudioSettingsMediator : 
        IAppInitListener,
        IAppPauseListener,
        IAppQuitListener
    {
        private const string PREFS_KEY = "AudioSettingsData";

        void IAppInitListener.Init()
        {
            this.LoadSettings();
        }
        
        void IAppPauseListener.OnPaused()
        {
            this.SaveSettings();
        }

        void IAppQuitListener.OnQuit()
        {
            this.SaveSettings();
        }

        private void LoadSettings()
        {
            if (ES3.KeyExists(PREFS_KEY))
            {
                var data = ES3.Load<AudioSettingsData>(PREFS_KEY);
                AudioSettingsManager.SetMusicVolume(data.musicVolume);
                AudioSettingsManager.SetSoundVolume(data.soundVolume);
            }
            else
            {
                AudioSettingsManager.SetMusicVolumeDefault();
                AudioSettingsManager.SetSoundVolumeDefault();
            }
        }

        private void SaveSettings()
        {
            AudioSettingsData data = new AudioSettingsData
            {
                musicVolume = AudioSettingsManager.MusicVolume,
                soundVolume = AudioSettingsManager.SoundVolume
            };
            
            ES3.Save(PREFS_KEY, data);
        }
    }
}