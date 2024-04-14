using System;

namespace Elementary
{
    public interface IVariable<T> : IValue<T>
    {
        event Action<T> OnValueChanged;

        new T Current { get; set; }
    }
}