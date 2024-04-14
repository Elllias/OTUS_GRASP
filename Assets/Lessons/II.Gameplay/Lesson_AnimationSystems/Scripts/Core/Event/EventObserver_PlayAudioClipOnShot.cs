using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class EventObserver_PlayAudioClipOnShot : AbstractEventObserver
    {
        [SerializeField]
        private AudioSource source;

        [SerializeField]
        private AudioClip clip;

        protected override void OnEvent()
        {
            this.source.PlayOneShot(this.clip);
        }
    }
}