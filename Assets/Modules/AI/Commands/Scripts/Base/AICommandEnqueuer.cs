using System;
using System.Collections.Generic;
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace AI.Commands
{
    public class AICommandEnqueuer<T> : IAICommandEnqueuer<T>
    {
        public event Action<T, object> OnEnqueued;

        public event Action<T, object> OnInterrupted;

        public bool IsRunning
        {
            get { return this.commandQueue.Count > 0 || this.executor is {IsRunning: true}; }
        }

        private IAICommandExecutor<T> executor;

        private readonly Queue<(T, object)> commandQueue = new();

        public AICommandEnqueuer(IAICommandExecutor<T> executor)
        {
            this.executor = executor;
        }

        public void Construct(IAICommandExecutor<T> executor)
        {
            this.executor = executor;
        }

        public void Start()
        {
            this.executor.OnFinished += this.OnCommandFinished;
        }

        public void Stop()
        {
            this.executor.OnFinished -= this.OnCommandFinished;
        }
        
        public void Enqueue(T key, object args)
        {
            if (this.executor.IsRunning)
            {
                this.commandQueue.Enqueue(new (key, args));
            }
            else
            {
                this.executor.Execute(key, args);
            }
        }

        public void Interrupt()
        {
            this.executor.Interrupt();
            this.commandQueue.Clear();
        }

        public IEnumerable<(T, object)> GetQueue()
        {
            return this.commandQueue;
        }
        
        private void OnCommandFinished(T prevKey, object prevArgs)
        {
            if (this.commandQueue.Count > 0)
            {
                var (key, args) = this.commandQueue.Dequeue();
                this.executor.Execute(key, args);
            }
        }
    }
}