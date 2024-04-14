using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Declarative
{
    internal static class ReflectionUtils
    {
        private static readonly Type OBJECT_TYPE = typeof(object);

        private static readonly Type MONO_BEHAVIOUR_TYPE = typeof(MonoBehaviour);
        
        internal static List<MethodInfo> RetrieveMethods(Type targetType)
        {
            var result = new List<MethodInfo>();
            while (IsRetrievableType(targetType))
            {
                var methods = targetType.GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic | 
                    BindingFlags.DeclaredOnly
                );

                result.AddRange(methods);
                targetType = targetType.BaseType;
            }

            return result;
        }
        
        internal static List<FieldInfo> RetrieveFields(Type targetType)
        {
            var result = new List<FieldInfo>();
            while (IsRetrievableType(targetType))
            {
                var fields = targetType.GetFields(
                    BindingFlags.Instance |
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.DeclaredOnly
                );

                result.AddRange(fields);
                targetType = targetType.BaseType;
            }

            return result;
        }
        
        private static bool IsRetrievableType(Type type)
        {
            return type != null && type != OBJECT_TYPE && type != MONO_BEHAVIOUR_TYPE;
        }
    }
}