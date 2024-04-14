using System;
using Game.SceneAudio;
using UnityEngine;
using UnityEngine.Audio;

namespace Game.App
{
    public static class AudioSettingsManager
    {
        private const string MIXER_PATH = "AudioMixer";

        private const float DEFAULT_MUSIC_VOLUME = 0.5f;
        private const float DEFAULT_SOUND_VOLUME = 0.5f;

        public static event Action<float> OnMusicVolumeChangd;
        public static event Action<float> OnSoundVolumeChanged;

        public static float MusicVolume { get; private set; }
        public static float SoundVolume { get; private set; }

        private static AudioMixer mixer
        {
            get
            {
                if (_mixer == null)
                    _mixer = Resources.Load<AudioMixer>(MIXER_PATH);
                return _mixer;
            }
        }

        private static AudioMixer _mixer;

        public static void SetMusicVolumeDefault()
        {
            SetMusicVolume(DEFAULT_MUSIC_VOLUME);
        }

        public static void SetSoundVolumeDefault()
        {
            SetSoundVolume(DEFAULT_SOUND_VOLUME);
        }

        public static void SetMusicVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            MusicVolume = volume;
            
            // mixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));

            MusicManager.Volume = volume;
            OnMusicVolumeChangd?.Invoke(volume);
        }

        public static void SetSoundVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            SoundVolume = volume;

            // mixer.SetFloat("SoundVolume", Mathf.Lerp(-80, 0, volume));
            // mixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));

            UISoundManager.Volume = volume;
            SceneAudioManager.SetVolumeAll(volume);

            OnSoundVolumeChanged?.Invoke(volume);
        }
    }
}