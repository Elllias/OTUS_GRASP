using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class FloatVariableLimited : IVariableLimited<float>
    {
        public event Action<float> OnValueChanged;

        public event Action<float> OnMaxValueChanged;

        public float Current
        {
            get { return this.currentValue; }
            set { this.SetValue(value); }
        }

        public float MaxValue
        {
            get { return this.maxValue; }
            set { this.SetMaxValue(value); }
        }

        public bool IsLimit
        {
            get { return this.currentValue >= this.maxValue; }
        }

        private ActionComposite<float> onValueChanged;

        private ActionComposite<float> onMaxValueChanged;

        [OnValueChanged("SetValue")]
        [SerializeField]
        private float currentValue;

        [OnValueChanged("SetMaxValue")]
        [SerializeField]
        private float maxValue;

        public void AddListener(IAction<float> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<float> listener)
        {
            this.onValueChanged -= listener;
        }

        public void AddMaxListener(IAction<float> listener)
        {
            this.onMaxValueChanged += listener;
        }

        public void RemoveMaxListener(IAction<float> listener)
        {
            this.onMaxValueChanged -= listener;
        }
        
        public IAction<float> AddListener(Action<float> listener)
        {
            var actionDelegate = new ActionDelegate<float>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        public IAction<float> AddMaxListener(Action<float> listener)
        {
            var actionDelegate = new ActionDelegate<float>(listener);
            this.onMaxValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(float value)
        {
            value = Mathf.Clamp(value, 0, this.maxValue);
            this.currentValue = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }
        
        private void SetMaxValue(float value)
        {
            value = Math.Max(1, value);
            if (this.currentValue > value)
            {
                this.SetValue(value);
            }

            this.maxValue = value;
            this.onMaxValueChanged?.Do(value);
            this.OnMaxValueChanged?.Invoke(value);
        }
    }
}