using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class MapEntity : IEntity
    {
        private readonly Dictionary<Type, object> elements;

        public MapEntity()
        {
            this.elements = new Dictionary<Type, object>();
        }

        public MapEntity(Dictionary<Type, object> elements)
        {
            this.elements = new Dictionary<Type, object>(elements);
        }

        public T Get<T>()
        {
            if (this.elements.TryGetValue(typeof(T), out var element))
            {
                return (T) element;
            }

            throw new EntityException($"Element of type {typeof(T).Name} is not found!");
        }

        public object[] GetAll()
        {
            return this.elements.Values.ToArray();
        }

        public void Add<T>(T element)
        {
            if (this.elements.ContainsKey(typeof(T)))
            {
                throw new EntityException($"Element of type {typeof(T).Name} is already exists!");
            }
            
            this.elements.Add(typeof(T), element);
        }

        public void Remove<T>(T element)
        {
            this.elements.Remove(typeof(T));
        }

        public bool TryGet<T>(out T result)
        {
            if (this.elements.TryGetValue(typeof(T), out var element))
            {
                result = (T) element;
                return true;
            }

            result = default;
            return false;
        }
    }
}