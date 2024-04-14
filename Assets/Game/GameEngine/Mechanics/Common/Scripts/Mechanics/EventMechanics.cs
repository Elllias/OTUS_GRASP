using System;
using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class EventMechanics :
        IEnableListener,
        IDisableListener
    {
        private IEmitter emitter;

        private Action action;

        public void Construct(IEmitter emitter, Action action)
        {
            this.emitter = emitter;
            this.action = action;
        }

        void IEnableListener.OnEnable()
        {
            this.emitter.OnEvent += this.action;
        }

        void IDisableListener.OnDisable()
        {
            this.emitter.OnEvent -= this.action;
        }
    }
    
    public sealed class EventMechanics<T> :
        IEnableListener,
        IDisableListener
    {
        private IEmitter<T> emitter;

        private Action<T> action;

        public void Construct(IEmitter<T> emitter, Action<T> action)
        {
            this.emitter = emitter;
            this.action = action;
        }

        void IEnableListener.OnEnable()
        {
            this.emitter.OnEvent += this.action;
        }

        void IDisableListener.OnDisable()
        {
            this.emitter.OnEvent -= this.action;
        }
    }
}