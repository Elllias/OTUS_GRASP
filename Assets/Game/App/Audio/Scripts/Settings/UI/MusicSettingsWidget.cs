using Game.UI;
using Services;

namespace Game.App
{
    public sealed class MusicSettingsWidget : AudioSettingsWidget
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            AudioSettingsManager.OnMusicVolumeChangd += this.UpdateSlider;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            AudioSettingsManager.OnMusicVolumeChangd -= this.UpdateSlider;
        }

        protected override void SetVolume(float volume)
        {
            AudioSettingsManager.SetMusicVolume(volume);
        }

        protected override float GetVolume()
        {
            return AudioSettingsManager.MusicVolume;
        }
    }
}