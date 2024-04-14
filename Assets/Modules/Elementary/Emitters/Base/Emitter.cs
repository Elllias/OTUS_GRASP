using System;
using Sirenix.OdinInspector;

namespace Elementary
{
    public class Emitter : IEmitter
    {
        public event Action OnEvent;

        private ActionComposite actions;

        [Button, GUIColor(0, 1, 0)]
        public virtual void Call()
        {
            this.actions?.Do();
            this.OnEvent?.Invoke();
        }

        public IAction AddListener(Action action)
        {
            var actionDelegate = new ActionDelegate(action);
            this.actions += actionDelegate;
            return actionDelegate;
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
    
    public class Emitter<T> : IEmitter<T>
    {
        public event Action<T> OnEvent;

        private ActionComposite<T> actions;

        [Button, GUIColor(0, 1, 0)]
        public virtual void Call(T value)
        {
            this.actions?.Do(value);
            this.OnEvent?.Invoke(value);
        }

        public IAction<T> AddListener(Action<T> action)
        {
            var actionDelegate = new ActionDelegate<T>(action);
            this.actions += actionDelegate;
            return actionDelegate;
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