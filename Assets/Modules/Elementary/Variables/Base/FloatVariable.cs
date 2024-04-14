using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class FloatVariable : IVariable<float>
    {
        public event Action<float> OnValueChanged;

        public float Current
        {
            get { return this.value; }
            set { this.SetValue(value); }
        }
        
        [OnValueChanged("SetValue")]
        [SerializeField]
        private float value;
        
        private ActionComposite<float> onValueChanged;

        public void AddListener(IAction<float> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<float> listener)
        {
            this.onValueChanged -= listener;
        }

        public IAction<float> AddListener(Action<float> listener)
        {
            var actionDelegate = new ActionDelegate<float>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(float value)
        {
            this.value = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }
    }
}