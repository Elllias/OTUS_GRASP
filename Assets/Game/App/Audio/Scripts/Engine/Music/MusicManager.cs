using System;
using UnityEngine;

namespace Game
{
    public sealed class MusicManager : MonoBehaviour
    {
        public static event Action<bool> OnMuted
        {
            add { if (instance != null) instance.player.OnMuted += value; }
            remove { if (instance != null) instance.player.OnMuted -= value; }
        }

        public static event Action<float> OnVolumeChanged
        {
            add { if (instance != null) instance.player.OnVolumeChanged += value; }
            remove { if (instance != null) instance.player.OnVolumeChanged -= value; }
        }

        public static event Action OnStarted
        {
            add { if (instance != null) instance.player.OnStarted += value; }
            remove { if (instance != null) instance.player.OnStarted -= value; }
        }

        public static event Action OnPaused
        {
            add { if (instance != null) instance.player.OnPaused += value; }
            remove { if (instance != null) instance.player.OnPaused -= value; }
        }

        public static event Action OnResumed
        {
            add { if (instance != null) instance.player.OnResumed += value; }
            remove { if (instance != null) instance.player.OnResumed -= value; }
        }

        public static event Action OnStopped
        {
            add { if (instance != null) instance.player.OnStopped += value; }
            remove { if (instance != null) instance.player.OnStopped -= value; }
        }

        public static event Action OnFinsihed
        {
            add { if (instance != null) instance.player.OnFinsihed += value; }
            remove { if (instance != null) instance.player.OnFinsihed -= value; }
        }

        public static bool IsMute
        {
            get { return instance != null && instance.player.IsMute; }
            set { if (instance != null) instance.player.IsMute = value; }
        }

        public static float Volume
        {
            get { return instance != null ? instance.player.Volume : 0; }
            set { if (instance != null) instance.player.Volume = value; }
        }

        public static MusicState State
        {
            get { return instance != null ? instance.player.State : MusicState.IDLE; }
        }

        public static AudioClip CurrentMusic
        {
            get { return instance != null ? instance.player.CurrentMusic : null; }
        }

        private static MusicManager instance;

        [SerializeField]
        private MusicPlayer player;

        public static void Play(AudioClip music)
        {
            if (instance != null)
                instance.player.Play(music);
        }

        public static void Pause()
        {
            if (instance != null)
                instance.player.Pause();
        }

        public static void Resume()
        {
            if (instance != null)
                instance.player.Resume();
        }

        public static void Stop()
        {
            if (instance != null)
                instance.player.Stop();
        }

        private void Awake()
        {
            if (instance != null)
                throw new Exception("Music Player is already created!");

            instance = this;
        }

        private void OnDestroy()
        {
            instance = null;
        }
    }
}