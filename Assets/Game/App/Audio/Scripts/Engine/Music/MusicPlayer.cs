using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public sealed class MusicPlayer : MonoBehaviour
    {
        public event Action<bool> OnMuted;
        public event Action<float> OnVolumeChanged;
        public event Action OnStarted;
        public event Action OnPaused;
        public event Action OnResumed;
        public event Action OnStopped;
        public event Action OnFinsihed;

        public bool IsMute
        {
            get { return this.isMute; }
            set { this.SetMute(value); }
        }

        public float Volume
        {
            get { return this.audioSource.volume; }
            set { this.SetVolume(value); }
        }

        [PropertySpace(8.0f)]
        [ReadOnly]
        [ShowInInspector]
        [PropertyOrder(-8)]
        public MusicState State
        {
            get { return this.state; }
        }

        [PropertyOrder(-7)]
        [ReadOnly]
        [ShowInInspector]
        public AudioClip CurrentMusic
        {
            get { return this.GetCurrentMusic(); }
        }

        [PropertyOrder(-6)]
        [ReadOnly]
        [ShowInInspector]
        [ProgressBar(min: 0, max: 1, r: 1f, g: 0.83f, b: 0f)]
        public float PlayingProgress
        {
            get { return this.GetPlayingProgress(); }
        }

        [PropertySpace(8.0f)]
        [PropertyOrder(-10)]
        [SerializeField]
        private bool isMute;

        [PropertyOrder(-9)]
        [Range(0, 1.0f)]
        [SerializeField]
        private float volume;
        
        private MusicState state;

        [PropertySpace(8.0f)]
        [PropertyOrder(-2)]
        [SerializeField]
        private AudioSource audioSource;
        
        [PropertySpace(8.0f)]
        [SerializeField]
        private bool randomizePitch = true;

        [SerializeField, ShowIf(nameof(randomizePitch))]
        private float pitchOffset = 0.2f;

        [Title("Methods")]
        [GUIColor(1f, 0.83f, 0f)]
        [Button]
        public void Play(AudioClip music)
        {
            if (this.state != MusicState.IDLE)
            {
                Debug.LogWarning("Music is already started!");
                return;
            }

            this.state = MusicState.PLAYING;
            
            if (this.randomizePitch)
            {
                this.audioSource.pitch = Random.Range(1 - this.pitchOffset, 1 + this.pitchOffset);
            }
            
            this.audioSource.clip = music;
            this.audioSource.Play();
            this.OnStarted?.Invoke();
        }

        [GUIColor(1f, 0.83f, 0f)]
        [Button]
        public void Pause()
        {
            if (this.state != MusicState.PLAYING)
            {
                Debug.LogWarning("Music is not playing!");
                return;
            }

            this.state = MusicState.PAUSED;
            this.audioSource.Pause();
            this.OnPaused?.Invoke();
        }

        [GUIColor(1f, 0.83f, 0f)]
        [Button]
        public void Resume()
        {
            if (this.state != MusicState.PAUSED)
            {
                Debug.LogWarning("Music is not paused!");
                return;
            }

            this.state = MusicState.PLAYING;
            this.audioSource.UnPause();
            this.OnResumed?.Invoke();
        }

        [GUIColor(1f, 0.83f, 0f)]
        [Button]
        public void Stop()
        {
            if (this.state == MusicState.IDLE)
            {
                Debug.LogWarning("Music is not playing!");
                return;
            }

            this.state = MusicState.IDLE;
            this.audioSource.Stop();
            this.audioSource.clip = null;
            this.OnStopped?.Invoke();
        }

        private void Finish()
        {
            this.state = MusicState.IDLE;
            this.audioSource.Stop();
            this.audioSource.clip = null;
            this.OnFinsihed?.Invoke();
        }

        private void Awake()
        {
            this.audioSource.volume = this.volume;
            this.audioSource.mute = this.isMute;
            this.state = MusicState.IDLE;
        }

        private void Update()
        {
            if (this.state == MusicState.PLAYING && this.audioSource.time >= this.audioSource.clip.length)
            {
                this.Finish();
            }
        }

        private void SetVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            if (Mathf.Approximately(volume, this.volume))
            {
                return;
            }

            this.volume = volume;
            this.audioSource.volume = volume;
            this.OnVolumeChanged?.Invoke(volume);
        }

        private void SetMute(bool mute)
        {
            if (this.isMute == mute)
            {
                return;
            }

            this.isMute = mute;
            this.audioSource.mute = mute;
            this.OnMuted?.Invoke(mute);
        }

        private float GetPlayingProgress()
        {
            if (this.state == MusicState.IDLE)
            {
                return 0.0f;
            }

            if (this.audioSource == null || this.audioSource.clip == null)
            {
                return 0.0f;
            }

            return this.audioSource.time / this.audioSource.clip.length;
        }
        
        private AudioClip GetCurrentMusic()
        {
            if (this.audioSource != null)
            {
                return this.audioSource.clip;
            }

            return null;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                this.audioSource.volume = this.volume;
                this.audioSource.mute = this.isMute;
            }
            catch (Exception)
            {
            }
        }
#endif
    }
}