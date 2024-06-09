using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.DI
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static T GetService<T>() where T : class
        {
            return _services[typeof(T)] as T;
        }

        public static void BindService(Type type, object service)
        {
            _services.Add(type, service);
        }
    }
}