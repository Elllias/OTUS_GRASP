using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class Blackboard : MonoBehaviour
    {
        public event Action<string, object> OnVariableChanged;
        public event Action<string, object> OnVariableRemoved;

        [ShowInInspector, ReadOnly]
        private readonly Dictionary<string, object> variables = new();

        public T GetVariable<T>(string key)
        {
            return (T) this.variables[key];
        }

        public bool TryGetVariable<T>(string key, out T value)
        {
            if (this.variables.TryGetValue(key, out var result))
            {
                value = (T) result;
                return true;
            }
            
            value = default;
            return false;
        }

        public bool HasVariable(string key)
        {
            return this.variables.ContainsKey(key);
        }
        
        [Title("Methods")]
        [Button]
        public void SetVariable(string key, object value)
        {
            this.variables[key] = value;
            this.OnVariableChanged?.Invoke(key, value);
        }
        
        [Button]
        public void RemoveVariable(string key)
        {
            if (this.variables.TryGetValue(key, out var value))
            {
                this.variables.Remove(key);
                this.OnVariableRemoved?.Invoke(key, value);
            }
        }
    }
}