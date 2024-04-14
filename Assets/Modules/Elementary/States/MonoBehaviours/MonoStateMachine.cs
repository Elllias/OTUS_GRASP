using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    public abstract class MonoStateMachine<T> : MonoState,
        IStateMachine<T>,
        ISerializationCallbackReceiver
    {
        public event Action<T> OnStateSwitched;

        public T CurrentState
        {
            get { return this.mode; }
        }

        [Space]
        [SerializeField]
        private bool enterOnEnable;

        [SerializeField]
        private bool exitOnDisable;

        [OnValueChanged("SwitchState")]
        [Space]
        [SerializeField]
        private T mode;

        [SerializeField]
        private StateHolder[] states = Array.Empty<StateHolder>();

        private Dictionary<T, MonoState> stateMap;

        private MonoState currentState;

        protected virtual void OnEnable()
        {
            if (this.enterOnEnable)
            {
                this.Enter();
            }
        }

        protected virtual void OnDisable()
        {
            if (this.exitOnDisable)
            {
                this.Exit();
            }
        }

        public virtual void SwitchState(T state)
        {
            if (!ReferenceEquals(this.currentState, null))
            {
                this.currentState.Exit();
            }

            if (this.stateMap.TryGetValue(state, out this.currentState))
            {
                this.currentState.Enter();
            }

            this.mode = state;
            this.OnStateSwitched?.Invoke(state);
        }

        public override void Enter()
        {
            if (ReferenceEquals(this.currentState, null) &&
                this.stateMap.TryGetValue(this.mode, out this.currentState))
            {
                this.currentState.Enter();
            }
        }

        public override void Exit()
        {
            if (!ReferenceEquals(this.currentState, null))
            {
                this.currentState.Exit();
                this.currentState = null;
            }
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.stateMap = new Dictionary<T, MonoState>();
            foreach (var info in this.states)
            {
                this.stateMap[info.mode] = info.state;
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }

        [Serializable]
        private struct StateHolder
        {
            [SerializeField]
            public T mode;

            [SerializeField]
            public MonoState state;
        }
    }
}