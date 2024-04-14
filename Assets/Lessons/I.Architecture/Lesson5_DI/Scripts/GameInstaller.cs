using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Lessons.Architecture.DI
{
    public abstract class GameInstaller : MonoBehaviour,
        IGameListenerProvider,
        IServiceProvider,
        IInjectProvider
    {
        public virtual IEnumerable<IGameListener> ProvideListeners()
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                if (field.IsDefined(typeof(ListenerAttribute)) && 
                    field.GetValue(this) is IGameListener gameListener)
                {
                    yield return gameListener;
                }
            }
        }

        public virtual IEnumerable<(Type, object)> ProvideServices()
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<ServiceAttribute>();
                if (attribute != null)
                {
                    Type type = attribute.contract;
                    object service = field.GetValue(this);
                    yield return (type, service);
                }
            }
        }

        public virtual void Inject(ServiceLocator serviceLocator)
        {
            FieldInfo[] fields = this.GetType().GetFields(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.DeclaredOnly
            );

            foreach (var field in fields)
            {
                var target = field.GetValue(this);
                DependencyInjector.Inject(target, serviceLocator);
            }
        }

        // public override void Inject(ServiceLocator serviceLocator)
        // {
   
        // }
    }
}