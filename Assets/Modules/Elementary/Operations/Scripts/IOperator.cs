using System;

namespace Elementary
{
    public interface IOperator<T>
    {
        event Action<T> OnStarted;

        event Action<T> OnStopped;

        bool IsActive { get; }

        T Current { get; }

        bool CanStart(T operation);

        void DoStart(T operation);

        void Stop();
    }
}