using UnityEngine;

namespace Elementary
{
    public abstract class ScriptableEffectHandler<T> : ScriptableObject, IEffectHandler<T>
    {
        public abstract void OnApply(T effect);
        
        public abstract void OnDiscard(T effect);
    }
}