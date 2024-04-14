using Game.UI;
using Services;

namespace Game.App
{
    public sealed class SoundSettingsWidget : AudioSettingsWidget
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            AudioSettingsManager.OnSoundVolumeChanged += this.UpdateSlider;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            AudioSettingsManager.OnSoundVolumeChanged -= this.UpdateSlider;
        }

        protected override void SetVolume(float volume)
        {
            AudioSettingsManager.SetSoundVolume(volume);
        }

        protected override float GetVolume()
        {
            return AudioSettingsManager.SoundVolume;
        }
    }
}