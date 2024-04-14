using System;
using Sirenix.OdinInspector;

namespace Lessons.Utils
{
    public interface IAtomicValue<out T>
    {
        T Value { get; }
    }
    
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        [ShowInInspector, ReadOnly]
        public T Value
        {
            get { return this.func.Invoke(); }
        }

        private readonly Func<T> func;

        public AtomicValue(Func<T> func)
        {
            this.func = func;
        }
    }
}