using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    public sealed class Variable<T> : IVariable<T>
    {
        public event Action<T> OnValueChanged;

        public T Current
        {
            get { return this.value; }
            set { this.SetValue(value); }
        }
        
        [OnValueChanged("SetValue")]
        [ShowInInspector]
        private T value;
        
        private ActionComposite<T> onValueChanged;

        public void AddListener(IAction<T> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<T> listener)
        {
            this.onValueChanged -= listener;
        }

        public IAction<T> AddListener(Action<T> listener)
        {
            var actionDelegate = new ActionDelegate<T>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(T value)
        {
            this.value = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }
    }
}