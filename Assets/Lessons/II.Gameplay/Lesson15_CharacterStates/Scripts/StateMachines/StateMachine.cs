using System;
using System.Collections.Generic;
using Lessons.StateMachines.States;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.StateMachines
{
    [Serializable]
    public class StateMachine<T> : IState
    {
        public T CurrentState
        {
            get { return this.currentStateType; }
        }

        [SerializeField]
        protected T currentStateType;

        [ShowInInspector, ReadOnly]
        private IState _currentState;

        private List<(T, IState)> _states = new();

        public void Construct(params (T, IState)[] states)
        {
            _states = new List<(T, IState)>(states);
        }

        public void Enter()
        {
            _currentState = FindState(currentStateType);
            _currentState?.Enter();
        }

        public void Exit()
        {
            _currentState?.Exit();
            _currentState = null;
        }

        public virtual void SwitchState(T stateType)
        {
            Exit();
            currentStateType = stateType;
            Enter();
        }

        private IState FindState(T stateType)
        {
            foreach (var state in _states)
            {
                if (state.Item1.Equals(stateType))
                {
                    return state.Item2;
                }
            }

            return null;
        }
    }
}