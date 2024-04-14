namespace Game.SceneAudio
{
    public interface ISceneAudioListener
    {
        void OnEnabled(bool enabled);

        void OnVolumeChanged(float volume);
    }
}