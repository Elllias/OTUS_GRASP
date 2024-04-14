using System;
using System.Reflection;
using UnityEngine;

namespace Declarative
{
    internal static class SectionConstructor
    {
        private static readonly Type CONSTRUCT_ATTRIBUTE_TYPE = typeof(ConstructAttribute);
        
        private static readonly Type GAME_OBJECT_TYPE = typeof(GameObject);

        private static readonly Type MONO_BEHAVIOUR_TYPE = typeof(MonoBehaviour);

        private static readonly Type TRANSFORM_TYPE = typeof(Transform);
        
        internal static void ConstructSection(object section, DeclarativeModel root)
        {
            var sectionType = section.GetType();
            var methods = ReflectionUtils.RetrieveMethods(sectionType);
            for (int i = 0, count = methods.Count; i < count; i++)
            {
                var method = methods[i];
                if (method.IsDefined(CONSTRUCT_ATTRIBUTE_TYPE))
                {
                    var args = ResolveArgs(root, method);
                    method.Invoke(section, args);
                }
            }
        }

        private static object[] ResolveArgs(DeclarativeModel root, MethodInfo method)
        {
            var parameters = method.GetParameters();
            var count = parameters.Length;

            var args = new object[count];
            for (var i = 0; i < count; i++)
            {
                var parameter = parameters[i];
                var parameterType = parameter.ParameterType;
                args[i] = ResolveArg(root, parameterType);
            }

            return args;
        }

        private static object ResolveArg(DeclarativeModel root, Type parameterType)
        {
            if (parameterType == GAME_OBJECT_TYPE)
            {
                return root.gameObject;
            }

            if (parameterType == MONO_BEHAVIOUR_TYPE)
            {
                return root;
            }

            if (parameterType == TRANSFORM_TYPE)
            {
                return root.transform;
            }

            if (root.TryGetSection(parameterType, out var section))
            {
                return section;
            }

            Debug.LogWarning($"Can't find section {parameterType.Name}");
            return null;
        }
    }
}