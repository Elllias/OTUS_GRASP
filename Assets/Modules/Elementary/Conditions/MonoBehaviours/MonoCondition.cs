using UnityEngine;

namespace Elementary
{
    public abstract class MonoCondition : MonoBehaviour, ICondition
    {
        public abstract bool IsTrue();
    }

    public abstract class MonoCondition<T> : MonoBehaviour, ICondition<T>
    {
        public abstract bool IsTrue(T value);
    }
}