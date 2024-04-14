using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Commands
{
    public abstract class UnityAICommandEnqueuer<T> : MonoBehaviour, IAICommandEnqueuer<T>
    {
        public event Action<T, object> OnEnqueued
        {
            add { this.enqueuer.OnEnqueued += value; }
            remove { this.enqueuer.OnEnqueued -= value; }
        }

        public event Action<T, object> OnInterrupted
        {
            add { this.enqueuer.OnInterrupted += value; }
            remove { this.enqueuer.OnInterrupted -= value; }
        }

        public bool IsRunning
        {
            get { return this.enqueuer.IsRunning; }
        }

        [SerializeField]
        private UnityAICommandExecutor<T> executor;

        private IAICommandEnqueuer<T> enqueuer;

        private void Awake()
        {
            this.enqueuer = new AICommandEnqueuer<T>(this.executor);
        }

        public void Enqueue(T key, object args)
        {
            this.enqueuer.Enqueue(key, args);
        }

        public void Interrupt()
        {
            this.enqueuer.Interrupt();
        }

        public IEnumerable<(T, object)> GetQueue()
        {
            return this.enqueuer.GetQueue();
        }
    }
}