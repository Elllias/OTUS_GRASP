using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.SceneAudio
{
    public sealed class SceneAudioChannel : MonoBehaviour
    {
        private const float BLOCKED_AUDIO_DELAY = 0.1f;

        public bool IsEnabled
        {
            get { return this.isEnable; }
            set { this.SetEnable(value); }
        }

        public float Volume
        {
            get { return this.volume; }
            set { this.SetVolume(value); }
        }

        [SerializeField]
        private bool isEnable;

        [Range(0.0f, 1.0f)]
        [SerializeField]
        private float volume;

        [Space]
        [SerializeField]
        private AudioSource source;

        [SerializeField]
        private bool controlClips;
        
        private readonly List<BlockedAudio> blockedClips = new();
        private readonly List<BlockedAudio> cache = new();

        private readonly List<ISceneAudioListener> listeners = new();

        public void PlaySound(AudioClip clip)
        {
            if (!this.isEnable)
            {
                return;
            }

            var clipName = clip.name;
            
            if (this.controlClips)
            {
                if (this.IsBlocked(clipName))
                {
                    return;
                }

                this.blockedClips.Add(new BlockedAudio(clipName, BLOCKED_AUDIO_DELAY));
            }

            this.source.PlayOneShot(clip);
        }

        private void SetEnable(bool enable)
        {
            if (this.isEnable == enable)
            {
                return;
            }

            this.isEnable = enable;
            this.source.enabled = enable;

            for (int i = 0, count = this.listeners.Count; i < count; i++)
            {
                var observer = this.listeners[i];
                observer.OnEnabled(enable);
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
            this.source.volume = volume;

            for (int i = 0, count = this.listeners.Count; i < count; i++)
            {
                var observer = this.listeners[i];
                observer.OnVolumeChanged(volume);
            }
        }

        public void AddListener(ISceneAudioListener listener)
        {
            this.listeners.Add(listener);
        }

        public void RemoveListener(ISceneAudioListener listener)
        {
            this.listeners.Remove(listener);
        }

        private void Awake()
        {
            this.source.enabled = this.isEnable;
            this.source.volume = this.volume;
        }

        private void Update()
        {
            if (this.isEnable)
            {
                this.ProcessBlockedClips(Time.deltaTime);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                this.Awake();
            }
            catch (Exception)
            {
            }
        }
#endif

        private bool IsBlocked(string soundName)
        {
            for (int i = 0, count = this.blockedClips.Count; i < count; i++)
            {
                var clip = this.blockedClips[i];
                if (clip.name == soundName)
                {
                    return true;
                }
            }

            return false;
        }

        private void ProcessBlockedClips(float deltaTime)
        {
            if (!this.controlClips)
            {
                return;
            }
            
            this.cache.Clear();
            this.cache.AddRange(this.blockedClips);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var clip = this.cache[i];
                var remainingTime = clip.delay - deltaTime;

                if (remainingTime <= 0)
                {
                    this.blockedClips.RemoveAt(i);
                }
                else
                {
                    this.blockedClips[i] = new BlockedAudio(clip.name, remainingTime);
                }
            }
        }

        private readonly struct BlockedAudio
        {
            public readonly string name;
            public readonly float delay;

            public BlockedAudio(string name, float delay)
            {
                this.name = name;
                this.delay = delay;
            }
        }
    }
}