using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public abstract class AudioSettingsWidget : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        protected virtual void OnEnable()
        {
            this.slider.onValueChanged.AddListener(this.OnVolumeChanged);
            this.slider.value = this.GetVolume();
        }

        protected virtual void OnDisable()
        {
            this.slider.onValueChanged.RemoveListener(this.OnVolumeChanged);
        }

        private void OnVolumeChanged(float volume)
        {
            this.SetVolume(volume);
        }

        protected abstract void SetVolume(float volume);
        
        protected abstract float GetVolume();
        
        protected void UpdateSlider(float volume)
        {
            this.slider.value = volume;
        }
    }
}