using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class DestroyMechanics_PlaySoundOneShot : DestroyMechanics
    {
        [SerializeField]
        public AudioSource audioSource;

        [SerializeField]
        public AudioClip sound;

        protected override void Destroy(DestroyArgs destroyArgs)
        {
            this.audioSource.PlayOneShot(this.sound);
        }
    }
}