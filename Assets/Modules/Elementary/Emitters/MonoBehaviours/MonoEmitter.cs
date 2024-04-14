using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Elementary
{
    [AddComponentMenu("Elementary/Emitters/Emitter")]
    public sealed class MonoEmitter : MonoBehaviour, IEmitter
    {
        public event Action OnEvent;
        
        [SerializeField]
        private UnityEvent onEvent;
        
        private ActionComposite actions;

        [Button, GUIColor(0, 1, 0)]
        public void Call()
        {
            this.actions?.Do();
            this.onEvent.Invoke();
            this.OnEvent?.Invoke();
        }

        public void AddListener(IAction listener)
        {
            this.actions += listener;
        }

        public void RemoveListener(IAction listener)
        {
            this.actions -= listener;
        }
    }

    public abstract class MonoEmitter<T> : MonoBehaviour, IEmitter<T>
    {
        public event Action<T> OnEvent;

        [SerializeField]
        private UnityEvent<T> onEvent;

        private ActionComposite<T> actions;

        [Button, GUIColor(0, 1, 0)]
        public void Call(T value)
        {
            this.actions?.Do(value);
            this.onEvent?.Invoke(value);
            this.OnEvent?.Invoke(value);
        }

        public void AddListener(IAction<T> listener)
        {
            this.actions += listener;
        }

        public void RemoveListener(IAction<T> listener)
        {
            this.actions -= listener;
        }
    }
}