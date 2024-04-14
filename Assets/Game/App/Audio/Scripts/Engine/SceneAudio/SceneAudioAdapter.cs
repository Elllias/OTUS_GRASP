using UnityEngine;
using UnityEngine.Serialization;

namespace Game.SceneAudio
{
    public sealed class SceneAudioAdapter : MonoBehaviour, ISceneAudioListener
    {
        [FormerlySerializedAs("channelType")]
        [SerializeField]
        private SceneAudioType audioType;

        [Space]
        [SerializeField]
        private AudioSource[] audioSources;

        private void OnEnable()
        {
            if (SceneAudioManager.IsInitialized)
            {
                this.Initialize();
            }
            else
            {
                SceneAudioManager.OnInitialized += this.Initialize;
            }
        }

        private void OnDisable()
        {
            SceneAudioManager.RemoveListener(this.audioType, this);
        }

        private void Initialize()
        {
            SceneAudioManager.OnInitialized -= this.Initialize;
            SceneAudioManager.AddListener(this.audioType, this);
            this.SetEnable(SceneAudioManager.IsEnable(this.audioType));
            this.SetVolume(SceneAudioManager.GetVolume(this.audioType));
        }

        void ISceneAudioListener.OnEnabled(bool enabled)
        {
            this.SetEnable(enabled);
        }

        void ISceneAudioListener.OnVolumeChanged(float volume)
        {
            this.SetVolume(volume);
        }
        
        private void SetEnable(bool enabled)
        {
            for (int i = 0, count = this.audioSources.Length; i < count; i++)
            {
                var source = this.audioSources[i];
                source.enabled = enabled;
            }
        }

        private void SetVolume(float volume)
        {
            for (int i = 0, count = this.audioSources.Length; i < count; i++)
            {
                var source = this.audioSources[i];
                source.volume = volume;
            }
        }
    }
}