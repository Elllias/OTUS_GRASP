using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Core
{
    [UsedImplicitly]
    public sealed class EventBus
    {
        private readonly Dictionary<Type, IEventHandlerCollection> _handlers = new();
        
        public void Subscribe<T>(Action<T> handler)
        {
            Type evtType = typeof(T);

            if (!_handlers.ContainsKey(evtType))
            {
                _handlers.Add(evtType, new EventHandlerCollection<T>());
            }
            
            _handlers[evtType].Subscribe(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            Type evtType = typeof(T);

            if (_handlers.TryGetValue(evtType, out var handlers))
            {
                handlers.Unsubscribe(handler);
            }
        }

        public void RaiseEvent<T>(T evt)
        {
            Type evtType = typeof(T);
            Debug.Log(evtType);

            if (!_handlers.TryGetValue(evtType, out var handlers))
            {
                Debug.LogWarning($"No found subscribers of type: {evtType}");
                return;
            }
            
            handlers.RaiseEvent(evt);
        }
        
        private interface IEventHandlerCollection
        {
            public void Subscribe(Delegate handler);

            public void Unsubscribe(Delegate handler);

            public void RaiseEvent<T>(T evt);
        }

        private sealed class EventHandlerCollection<T> : IEventHandlerCollection
        {
            private readonly List<Delegate> _handlers = new();

            private int _currentIndex = -1;
            
            public void Subscribe(Delegate handler)
            {
                _handlers.Add(handler);
            }

            public void Unsubscribe(Delegate handler)
            {
                int index = _handlers.IndexOf(handler);
                _handlers.RemoveAt(index);

                if (index <= _currentIndex)
                {
                    _currentIndex--;
                }
            }

            public void RaiseEvent<TEvent>(TEvent evt)
            {
                if (evt is not T concreteEvent)
                {
                    return;
                }
                
                for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
                {
                    var handler = (Action<T>) _handlers[_currentIndex];
                    handler.Invoke(concreteEvent);
                }

                _currentIndex = -1;
            }
        }
    }
}