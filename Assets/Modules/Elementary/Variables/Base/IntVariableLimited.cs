using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class IntVariableLimited : IVariableLimited<int>
    {
        public event Action<int> OnValueChanged;

        public event Action<int> OnMaxValueChanged;

        public int Current
        {
            get { return this.currentValue; }
            set { this.SetValue(value); }
        }

        public int MaxValue
        {
            get { return this.maxValue; }
            set { this.SetMaxValue(value); }
        }

        public bool IsLimit
        {
            get { return this.currentValue >= this.maxValue; }
        }

        private ActionComposite<int> onValueChanged;

        private ActionComposite<int> onMaxValueChanged;

        [OnValueChanged("SetValue")]
        [SerializeField]
        private int currentValue;

        [OnValueChanged("SetMaxValue")]
        [SerializeField]
        private int maxValue;

        public void AddListener(IAction<int> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<int> listener)
        {
            this.onValueChanged -= listener;
        }

        public void AddMaxListener(IAction<int> listener)
        {
            this.onMaxValueChanged += listener;
        }

        public void RemoveMaxListener(IAction<int> listener)
        {
            this.onMaxValueChanged -= listener;
        }

        public IAction<int> AddListener(Action<int> listener)
        {
            var actionDelegate = new ActionDelegate<int>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        public IAction<int> AddMaxListener(Action<int> listener)
        {
            var actionDelegate = new ActionDelegate<int>(listener);
            this.onMaxValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(int value)
        {
            value = Mathf.Clamp(value, 0, this.maxValue);
            this.currentValue = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }

        private void SetMaxValue(int value)
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