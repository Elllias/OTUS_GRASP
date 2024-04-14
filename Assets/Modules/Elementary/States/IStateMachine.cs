using System;

namespace Elementary
{
    public interface IStateMachine<T> : IState
    {
        event Action<T> OnStateSwitched;

        public T CurrentState { get; }

        void SwitchState(T key);
    }
}