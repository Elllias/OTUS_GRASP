using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    public abstract class MonoOperator<T> : MonoBehaviour, IOperator<T>
    {
        public event Action<T> OnStarted;

        public event Action<T> OnStopped;

        [PropertySpace]
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsActive
        {
            get { return this.Current != null; }
        }

        [PropertyOrder(-9)]
        [ReadOnly]
        [ShowInInspector]
        public T Current { get; private set; }

        [SerializeField]
        private MonoCondition<T>[] preconditions;

        [SerializeField]
        private MonoAction<T>[] startActions;

        [SerializeField]
        private MonoAction<T>[] stopActions;

        public bool CanStart(T operation)
        {
            if (this.IsActive)
            {
                return false;
            }

            for (int i = 0, count = this.preconditions.Length; i < count; i++)
            {
                var condition = this.preconditions[i];
                if (!condition.IsTrue(operation))
                {
                    return false;
                }
            }

            return true;
        }

        [Title("Methods")]
        [Button]
        public void DoStart(T operation)
        {
            if (!this.CanStart(operation))
            {
                Debug.LogWarning("Can't start combat!", this);
                return;
            }

            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.Current = operation;
            this.OnStarted?.Invoke(operation);
        }

        [Button]
        public void Stop()
        {
            if (!this.IsActive)
            {
                Debug.LogWarning("Combat is not started!", this);
                return;
            }

            var operation = this.Current;
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.Current = default;
            this.OnStopped?.Invoke(operation);
        }
    }
}