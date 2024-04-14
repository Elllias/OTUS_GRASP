using System.Collections.Generic;
using UnityEngine;

namespace Game.SceneAudio
{
    public sealed class AudioSourcePool : MonoBehaviour
    {
        [SerializeField]
        private int poolSize = 32;

        [Space]
        [SerializeField]
        private Transform inactiveParent;

        [SerializeField]
        private Transform activeParent;

        [Space]
        [SerializeField]
        private AudioSource prefab;

        private readonly Queue<AudioSource> availableSources;

        public AudioSourcePool()
        {
            this.availableSources = new Queue<AudioSource>();
        }

        private void Awake()
        {
            this.inactiveParent.gameObject.SetActive(false);
            this.activeParent.gameObject.SetActive(true);

            for (var i = 0; i < this.poolSize; i++)
            {
                var source = Instantiate(this.prefab, this.inactiveParent);
                this.availableSources.Enqueue(source);
            }
        }

        public AudioSource Get()
        {
            AudioSource source;
            if (this.availableSources.Count > 0)
            {
                source = this.availableSources.Dequeue();
                source.transform.SetParent(this.activeParent);
            }
            else
            {
                source = Instantiate(this.prefab, this.activeParent);
                this.poolSize++;
            }

            return source;
        }

        public void Release(AudioSource source)
        {
            source.transform.SetParent(this.inactiveParent);
            this.availableSources.Enqueue(source);
        }
    }
}