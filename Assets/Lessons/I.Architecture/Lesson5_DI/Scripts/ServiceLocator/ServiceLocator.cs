using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.DI
{
    public sealed class ServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> services = new();

        public object GetService(Type type)
        {
            return services[type];
        }
        
        public T GetService<T>() where T : class
        {
            return services[typeof(T)] as T;
        }

        public void BindService(Type type, object service)
        {
            services.Add(type, service);
        }
    }
}