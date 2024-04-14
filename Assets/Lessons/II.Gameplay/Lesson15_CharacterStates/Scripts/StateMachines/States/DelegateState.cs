using System;

namespace Lessons.StateMachines.States
{
    public sealed class DelegateState : IState
    {
        private readonly Action onEnter;
        private readonly Action onExit;

        public DelegateState(Action onEnter, Action onExit)
        {
            this.onEnter = onEnter;
            this.onExit = onExit;
        }

        void IState.Enter()
        {
            this.onEnter?.Invoke();
        }

        void IState.Exit()
        {
            this.onExit?.Invoke();
        }
    }
}