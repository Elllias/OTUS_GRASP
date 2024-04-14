using System;
using Elementary;
using Game.GameEngine.Mechanics;

namespace Game.GameEngine
{
    public sealed class Component_TakeDamage : 
        IComponent_TakeDamage,
        IComponent_OnDamageTaken
    {
        public event Action<TakeDamageArgs> OnDamageTaken
        {
            add { this.emitter.OnEvent += value; }
            remove { this.emitter.OnEvent -= value; }
        }

        private readonly IEmitter<TakeDamageArgs> emitter;

        public Component_TakeDamage(IEmitter<TakeDamageArgs> emitter)
        {
            this.emitter = emitter;
        }

        public void TakeDamage(TakeDamageArgs damageArgs)
        {
            this.emitter.Call(damageArgs);
        }
    }
}