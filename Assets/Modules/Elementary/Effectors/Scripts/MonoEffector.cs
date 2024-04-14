using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    public abstract class MonoEffector<T> : MonoBehaviour, IEffector<T>
    {
        public event Action<T> OnApplied;

        public event Action<T> OnDiscarded;

        [Space]
        [ShowInInspector, ReadOnly]
        private List<T> effects = new();

        [Space]
        [SerializeField]
        private List<MonoEffectHandler<T>> handlers = new();

        [Title("Methods")]
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
    }
}