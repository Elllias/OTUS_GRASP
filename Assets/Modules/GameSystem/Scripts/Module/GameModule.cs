using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace GameSystem
{
    ///FOR ADVANCED GAME ARCHITECTURE
    public abstract class GameModule : MonoBehaviour,
        IGameElementGroup,
        IGameServiceGroup,
        IGameConstructElement
    {
        private static readonly Type ELEMENT_ATTRIBUTE = typeof(GameElementAttribute);
        
        private static readonly Type SERVICE_ATTRIBUTE = typeof(GameServiceAttribute);

        private static readonly Type INJECT_ATTRIBUTE = typeof(GameInjectAttribute);
        
        private static readonly Type MONO_BEHAVIOUR_TYPE = typeof(MonoBehaviour);

        private static readonly Type OBJECT_TYPE = typeof(object);

        private List<Field> cachedFields
        {
            get
            {
                if (this._cachedFields == null)
                {
                    this._cachedFields = this.CacheFields();
                }

                return this._cachedFields;
            }
        }

        private List<Field> _cachedFields;

        private List<Field> CacheFields()
        {
            var result = new List<Field>();
            var type = this.GetType();
            var fields = type.GetFields(BindingFlags.Instance |
                                        BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.DeclaredOnly);
            for (int i = 0, count = fields.Length; i < count; i++)
            {
                var field = fields[i];
                var item = new Field
                {
                    type = field.FieldType,
                    value = field.GetValue(this),
                    isElement = field.IsDefined(ELEMENT_ATTRIBUTE),
                    isService = field.IsDefined(SERVICE_ATTRIBUTE)
                };
                result.Add(item);
            }

            return result;
        }

        public virtual IEnumerable<IGameElement> GetElements()
        {
            return this.ScanElements();
        }

        public virtual IEnumerable<object> GetServices()
        {
            return this.ScanServices();
        }

        public virtual void ConstructGame(GameContext context)
        {
            this.Construct(context);
        }

        protected IEnumerable<IGameElement> ScanElements()
        {
            var fields = this.cachedFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                if (field.isElement)
                {
                    yield return field.value as IGameElement;
                }
            }
        }

        private IEnumerable<object> ScanServices()
        {
            var fields = this.cachedFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                if (field.isService)
                {
                    yield return field.value;
                }
            }
        }
        
        protected void Construct(GameContext context)
        {
            var fields = this.cachedFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var field = fields[i];
                this.InjectObject(context, field.type, field.value);
            }
        }

        private void InjectObject(GameContext source, Type type, object target)
        {
            while (true)
            {
                if (type == null || type == OBJECT_TYPE || type == MONO_BEHAVIOUR_TYPE)
                {
                    break;
                }

                this.InjectByFields(source, target, type);
                this.InjectByMethods(source, target, type);

                type = type.BaseType;
            }
        }

        private void InjectByFields(GameContext context, object target, Type targetType)
        {
            var fields = targetType.GetFields(BindingFlags.Instance |
                                              BindingFlags.Public |
                                              BindingFlags.NonPublic |
                                              BindingFlags.DeclaredOnly);

            for (int i = 0, count = fields.Length; i < count; i++)
            {
                var field = fields[i];
                if (field.IsDefined(INJECT_ATTRIBUTE))
                {
                    this.InjectByField(context, target, field);
                }
            }
        }

        private void InjectByField(GameContext context, object target, System.Reflection.FieldInfo field)
        {
            var fieldType = field.FieldType;
            var value = this.ResolveReference(context, fieldType);
            field.SetValue(target, value);
        }

        private void InjectByMethods(GameContext context, object target, Type targetType)
        {
            var methods = targetType.GetMethods(BindingFlags.Instance |
                                                BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.DeclaredOnly);

            for (int i = 0, count = methods.Length; i < count; i++)
            {
                var method = methods[i];
                if (method.IsDefined(INJECT_ATTRIBUTE))
                {
                    this.InjectByMethod(context, target, method);
                }
            }
        }

        private void InjectByMethod(GameContext context, object target, MethodInfo method)
        {
            var parameters = method.GetParameters();
            var count = parameters.Length;

            var args = new object[count];
            for (var i = 0; i < count; i++)
            {
                var parameter = parameters[i];
                var parameterType = parameter.ParameterType;
                args[i] = this.ResolveReference(context, parameterType);
            }

            method.Invoke(target, args);
        }

        private object ResolveReference(GameContext context, Type type)
        {
            if (this.ResolveReferenceFromCache(type, out var arg))
            {
                return arg;
            }

            arg = GameInjector.ResolveReference(context, type);
            return arg;
        }

        private bool ResolveReferenceFromCache(Type type, out object value)
        {
            var fields = this.cachedFields;
            for (int i = 0, count = fields.Count; i < count; i++)
            {
                var metadata = fields[i];
                if (metadata.type == type)
                {
                    value = metadata.value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        protected T Instantiate<T>(GameContext context)
        {
            return (T) this.Instantiate(context, typeof(T));
        }

        protected object Instantiate(GameContext context, Type type)
        {
            var constructors = type.GetConstructors(System.Reflection.BindingFlags.Instance |
                                                    System.Reflection.BindingFlags.Public |
                                                    System.Reflection.BindingFlags.DeclaredOnly);

            for (var i = 0; i < constructors.Length; i++)
            {
                var constructor = constructors[i];
                if (constructor.IsDefined(INJECT_ATTRIBUTE))
                {
                    return InstantiateByConstructor(context, constructor);
                }
            }

            var defaultConstructor = type.GetConstructor(Type.EmptyTypes);
            if (defaultConstructor != null)
            {
                return defaultConstructor.Invoke(new object[0]);
            }

            throw new Exception("Constructor is not found!");
        }

        private object InstantiateByConstructor(GameContext context, ConstructorInfo constructor)
        {
            var parameters = constructor.GetParameters();
            var count = parameters.Length;

            var args = new object[count];
            for (var i = 0; i < count; i++)
            {
                var parameter = parameters[i];
                args[i] = this.ResolveReference(context, parameter.ParameterType);
            }

            return constructor.Invoke(args);
        }

        private struct Field
        {
            public Type type;
            public object value;
            public bool isElement;
            public bool isService;
        }
    }
}