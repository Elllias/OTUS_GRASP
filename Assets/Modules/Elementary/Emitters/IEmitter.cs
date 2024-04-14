using System;

namespace Elementary
{
    public interface IEmitter
    {
        event Action OnEvent;

        void Call();
    }

    public interface IEmitter<T>
    {
        event Action<T> OnEvent;

        void Call(T args);
    }
}