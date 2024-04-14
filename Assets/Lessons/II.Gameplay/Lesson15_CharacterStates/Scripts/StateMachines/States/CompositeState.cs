using System;
using System.Collections.Generic;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public class CompositeState : IState
    {
        private List<IState> _states = new();
        
        void IState.Enter()
        {
            foreach (var state in _states)
            {
                state.Enter();
            }
        }

        void IState.Exit()
        {
            foreach (var state in _states)
            {
                state.Exit();
            }
        }

        protected void SetStates(params IState[] states)
        {
            _states = new List<IState>(states);
        }
    }
}