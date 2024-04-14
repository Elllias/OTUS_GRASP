using System;
using Sirenix.OdinInspector;

namespace Lessons.Utils
{
    public interface IAtomicProcess
    {
        event Action OnStarted;
        event Action OnStopped;

        bool IsPlaying { get; }
        
        bool CanStart();
        void Start();
        void Stop();
    }
    
    public interface IAtomicProcess<T>
    {
        event Action<T> OnStarted;
        event Action<T> OnStopped;

        bool IsPlaying { get; }
        T State { get; }

        bool CanStart(T state);
        void Start(T state);
        void Stop();
    }
    
    [Serializable]
    public sealed class AtomicProcess : IAtomicProcess
    {
        public event Action OnStarted
        {
            add { this.onStarted += value; }
            remove { this.onStarted -= value; }
        }

        public event Action OnStopped
        {
            add { this.onStopped += value; }
            remove { this.onStopped -= value; }
        }

        public IAtomicValue<bool> Condition { get; set; }

        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private Action onStarted;
        private Action onStopped;
        
        private bool isPlaying;

        [Title("Methods")]
        [Button]
        public bool CanStart()
        {
            if (this.isPlaying)
            {
                return false;
            }

            if (this.Condition == null)
            {
                return true;
            }

            return this.Condition.Value;
        }

        [Button]
        public void Start()
        {
            if (!this.CanStart())
            {
                return;
            }

            this.isPlaying = true;
            this.onStarted?.Invoke();
        }

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                return;
            }

            this.isPlaying = false;
            this.onStopped?.Invoke();
        }
    }

    [Serializable]
    public sealed class AtomicProcess<T> : IAtomicProcess<T>
    {
        public event Action<T> OnStarted
        {
            add { this.onStarted += value; }
            remove { this.onStarted -= value; }
        }

        public event Action<T> OnStopped
        {
            add { this.onStopped += value; }
            remove { this.onStopped -= value; }
        }

        public Func<T, bool> Condition { get; set; }

        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        [ShowInInspector, ReadOnly]
        public T State
        {
            get { return this.state; }
        }

        private Action<T> onStarted;
        private Action<T> onStopped;
        
        private bool isPlaying;
        private T state;

        [Title("Methods")]
        [Button]
        public bool CanStart(T state)
        {
            if (this.isPlaying)
            {
                return false;
            }

            if (this.Condition == null)
            {
                return true;
            }

            return this.Condition.Invoke(state);
        }

        [Button]
        public void Start(T state)
        {
            if (!this.CanStart(state))
            {
                return;
            }

            this.isPlaying = true;
            this.state = state;
            this.onStarted?.Invoke(state);
        }

        [Button]
        public void Stop()
        {
            if (!this.isPlaying)
            {
                return;
            }

            this.isPlaying = false;

            var state = this.state;
            this.state = default;
            this.onStopped?.Invoke(state);
        }
    }
}