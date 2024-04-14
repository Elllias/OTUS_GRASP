using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Utils
{
    [Serializable]
    public class AtomicVariable<T>
    {
        public AtomicEvent<T> ValueChanged { get; set; } = new();

        public T Value
        {
            get => value;
            set => SetValue(value);
        }

        [OnValueChanged("OnValueChangedInEditor")]
        [SerializeField]
        private T value;

        public static implicit operator T(AtomicVariable<T> value)
        {
            return value.value;
        }

        public AtomicVariable()
        {
            value = default;
        }

        public AtomicVariable(T value)
        {
            this.value = value;
        }

        protected virtual void SetValue(T value)
        {
            this.value = value;
            ValueChanged?.Invoke(value);
        }
        
#if UNITY_EDITOR
        private void OnValueChangedInEditor(T _)
        {
            ValueChanged?.Invoke(value);
        }
#endif
    }
}