using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Lessons.Utils
{
    [Serializable]
    public sealed class AtomicEvent
    {
        private readonly List<Action> _actions = new();
        
        private int _index;
        
        public void Subscribe(Action action)
        {
            _actions.Add(action);
        }
        
        public void Unsubscribe(Action action)
        {
            _actions.Remove(action);
        }
        
        public static AtomicEvent operator+(AtomicEvent atomicEvent, Action action)
        {
            atomicEvent._actions.Add(action);
            return atomicEvent;
        }

        public static AtomicEvent operator-(AtomicEvent atomicEvent, Action action)
        {
            atomicEvent._actions.Remove(action);
            atomicEvent._index--;
            
            return atomicEvent;
        }

        [Button]
        public void Invoke()
        {
            for (_index = 0; _index < _actions.Count; ++_index)
            {
                var action = _actions[_index];
                action.Invoke();
            }
        }
    }

    [Serializable]
    public sealed class AtomicEvent<T>
    {
        private readonly List<Action<T>> _actions = new();
        private int _index;

        public void Subscribe(Action<T> action)
        {
            _actions.Add(action);
        }
        
        public void Unsubscribe(Action<T> action)
        {
            _actions.Remove(action);
        }
        
        public static AtomicEvent<T> operator+(AtomicEvent<T> atomicEvent, Action<T> action)
        {
            atomicEvent._actions.Add(action);
            return atomicEvent;
        }

        public static AtomicEvent<T> operator-(AtomicEvent<T> atomicEvent, Action<T> action)
        {
            atomicEvent._actions.Remove(action);
            atomicEvent._index--;
            
            return atomicEvent;
        }

        [Button]
        public void Invoke(T arg)
        {
            for (_index = 0; _index < _actions.Count; ++_index)
            {
                _actions[_index].Invoke(arg);
            }
        }
    }
}