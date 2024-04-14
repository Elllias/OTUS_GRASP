using System;
using System.Collections.Generic;

namespace AI.Commands
{
    public interface IAICommandEnqueuer<T>
    {
        event Action<T, object> OnEnqueued;

        event Action<T, object> OnInterrupted;

        bool IsRunning { get; }

        void Enqueue(T key, object args);

        void Interrupt();

        IEnumerable<(T, object)> GetQueue();
    }
}