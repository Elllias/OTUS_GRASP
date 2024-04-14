using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Elementary
{
    public sealed class Effector<T> : IEffector<T>
    {
        public event Action<T> OnApplied;

        public event Action<T> OnDiscarded;

        [ShowInInspector, ReadOnly]
        private readonly List<T> effects = new();

        private readonly List<IEffectHandler<T>> handlers = new();

        [Button]
        public void Apply(T effect)
        {
            for (var i = 0; i < this.handlers.Count; i++)
            {
                var handler = this.handlers[i];
                handler.OnApply(effect);
            }

            this.effects.Add(effect);
            this.OnApplied?.Invoke(effect);
        }

        [Button]
        public void Discard(T effect)
        {
            if (!this.effects.Remove(effect))
            {
                return;
            }

            for (var i = 0; i < this.handlers.Count; i++)
            {
                var handler = this.handlers[i];
                handler.OnDiscard(effect);
            }

            this.OnDiscarded?.Invoke(effect);
        }

        public bool IsExists(T effect)
        {
            return this.effects.Contains(effect);
        }

        public T[] GetEffects()
        {
            return this.effects.ToArray();
        }

        public void AddHandler(IEffectHandler<T> handler)
        {
            this.handlers.Add(handler);
        }

        public void RemoveHandler(IEffectHandler<T> handler)
        {
            this.handlers.Remove(handler);
        }
    }
}