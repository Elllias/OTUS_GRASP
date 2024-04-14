using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class IntVariable : IVariable<int>
    {
        public event Action<int> OnValueChanged;

        public int Current
        {
            get { return this.value; }
            set { this.SetValue(value); }
        }

#if ODIN_INSPECTOR
        [OnValueChanged("SetValue")]
#endif
        [SerializeField]
        private int value;

        private ActionComposite<int> onValueChanged;

        public void AddListener(IAction<int> listener)
        {
            this.onValueChanged += listener;
        }

        public void RemoveListener(IAction<int> listener)
        {
            this.onValueChanged -= listener;
        }

        public IAction<int> AddListener(Action<int> listener)
        {
            var actionDelegate = new ActionDelegate<int>(listener);
            this.onValueChanged += actionDelegate;
            return actionDelegate;
        }

        private void SetValue(int value)
        {
            this.value = value;
            this.onValueChanged?.Do(value);
            this.OnValueChanged?.Invoke(value);
        }
    }
}