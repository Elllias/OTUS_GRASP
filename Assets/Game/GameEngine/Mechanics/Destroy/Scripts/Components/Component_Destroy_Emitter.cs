using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Destroy_Emitter : 
        IComponent_Destoy,
        IComponent_OnDestroyed
    {
        public event Action OnDestroyed
        {
            add { this.emitter.OnEvent += value; }
            remove { this.emitter.OnEvent -= value; }
        }

        private readonly IEmitter emitter;

        public Component_Destroy_Emitter(IEmitter emitter)
        {
            this.emitter = emitter;
        }

        public void Destroy()
        {
            this.emitter.Call();
        }
    }
    
    public sealed class Component_Destroy_Emitter<T> : 
        IComponent_Destroy<T>,
        IComponent_OnDestroyed<T>
    {
        public event Action<T> OnDestroyed
        {
            add { this.emitter.OnEvent += value; }
            remove { this.emitter.OnEvent -= value; }
        }

        private readonly IEmitter<T> emitter;

        public Component_Destroy_Emitter(IEmitter<T> emitter)
        {
            this.emitter = emitter;
        }

        public void Destroy(T args)
        {
            this.emitter.Call(args);
        }
    }
}