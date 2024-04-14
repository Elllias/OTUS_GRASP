using System;
using System.Reflection;

namespace Lessons.Architecture.DI
{
    public static class DependencyInjector
    {
        public static void Inject(object target, ServiceLocator locator)
        {
            Type type = target.GetType();
            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.FlattenHierarchy
            );

            foreach (MethodInfo method in methods)
            {
                if (method.IsDefined(typeof(InjectAttribute)))
                {
                    InvokeConstruct(method, target, locator);
                }
            }
        }

        private static void InvokeConstruct(MethodInfo method, object target, ServiceLocator locator)
        {
            ParameterInfo[] parameters = method.GetParameters();
            
            int count = parameters.Length;
            object[] args = new object[count];

            for (int i = 0; i < count; i++)
            {
                ParameterInfo parameter = parameters[i];
                Type type = parameter.ParameterType;
                
                object service = locator.GetService(type);
                args[i] = service;
            }

            method.Invoke(target, args);
        }
    }
}