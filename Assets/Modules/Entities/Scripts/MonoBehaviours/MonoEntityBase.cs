using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public abstract class MonoEntityBase : MonoEntity
    {
        private readonly ListEntity entity = new();

        public override T Get<T>()
        {
            try
            {
                return this.entity.Get<T>();
            }
            catch (EntityException exception)
            {
                Debug.LogError(exception.Message, this);
                throw;
            }
        }

        public override object[] GetAll()
        {
            return this.entity.GetAll();
        }

        public T[] GetAll<T>()
        {
            return this.entity.GetAll<T>();
        }

        public void Add(object element)
        {
            this.entity.Add(element);
        }

        public void Remove(object element)
        {
            this.entity.Remove(element);
        }

        public void AddRange(params object[] elements)
        {
            this.entity.AddRange(elements);
        }

        public void AddRange(IEnumerable<object> elements)
        {
            this.entity.AddRange(elements);
        }

        public override bool TryGet<T>(out T element)
        {
            return this.entity.TryGet(out element);
        }
    }
}