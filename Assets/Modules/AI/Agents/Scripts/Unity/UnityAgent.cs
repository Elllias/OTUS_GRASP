using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Modules.AI.Unity
{
    public abstract class UnityAgent : MonoBehaviour, IAgent
    {
        public event Action OnStarted;

        public event Action OnStopped;

        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        protected bool isPlaying;

        [Button]
        public void Play()
        {
            if (this.isPlaying)
            {
                Debug.LogWarning($"Agent {this.GetType().Name} is already playing!");
                return;
            }

            this.OnStart();
            this.isPlaying = true;
            this.OnStarted?.Invoke();
        }

        protected abstract void OnStart();

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                Debug.LogWarning($"Agent {this.GetType().Name} is not playing!");
                return;
            }

            this.OnStop();
            this.isPlaying = false;
            this.OnStopped?.Invoke();
        }

        protected abstract void OnStop();
    }
}