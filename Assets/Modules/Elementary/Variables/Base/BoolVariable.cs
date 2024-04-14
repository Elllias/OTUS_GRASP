using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class BoolVariable : IVariable<bool>
    {
        public event Action<bool> OnValueChanged;
        
        public bool Current
        {
            get { return this.value; }
            set { this.SetValue(value); }
        }
        
        [OnValueChanged("SetValue")]
        [SerializeField]
        private bool value;
        
        private ActionComposite<bool> onValueChanged;

        public void AddListener(IAction<bool> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<bool> listener)
        {
            this.onValueChanged -= listener;
        }

        public IAction<bool> AddListener(Action<bool> listener)
        {
            var actionDelegate = new ActionDelegate<bool>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(bool value)
        {
            this.value = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }
    }
}