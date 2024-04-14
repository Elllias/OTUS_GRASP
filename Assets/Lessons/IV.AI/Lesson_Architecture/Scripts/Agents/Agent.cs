using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public abstract class Agent : SerializedMonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private bool isPlaying;

        [Button]
        public void Play()
        {
            if (this.isPlaying)
            {
                Debug.LogWarning("Agent is already started!");
                return;
            }
            
            this.isPlaying = true;
            this.OnStart();
        }

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                Debug.LogWarning("Agent is not started!");
                return;
            }

            this.isPlaying = false;
            this.OnStop();
        }

        protected abstract void OnStart();
        protected abstract void OnStop();
    }
}