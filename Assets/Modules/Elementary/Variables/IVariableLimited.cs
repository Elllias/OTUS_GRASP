using System;

namespace Elementary
{
    public interface IVariableLimited<T> : IVariable<T>
    {
        event Action<T> OnMaxValueChanged;
        
        T MaxValue { get; set; }
        
        bool IsLimit { get; }
    }
}