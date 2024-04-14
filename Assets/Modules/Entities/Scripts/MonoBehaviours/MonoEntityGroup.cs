using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity Group")]
    public sealed class MonoEntityGroup : MonoEntity
    {
        [SerializeField]
        private MonoEntity[] entities = new MonoEntity[0];

        public override T Get<T>()
        {
            for (int i = 0, count = this.entities.Length; i < count; i++)
            {
                var entity = this.entities[i];
                if (entity.TryGet(out T element))
                {
                    return element;
                }
            }

            throw new Exception($"Element of type {typeof(T).Name} is not found!");
        }

        public override bool TryGet<T>(out T element)
        {
            for (int i = 0, count = this.entities.Length; i < count; i++)
            {
                var entity = this.entities[i];
                if (entity.TryGet(out element))
                {
                    return true;
                }
            }

            element = default;
            return false;
        }

        public override object[] GetAll()
        {
            var result = new List<object>();
            foreach (var entity in this.entities)
            {
                result.AddRange(entity.GetAll());
            }

            return result.ToArray();
        }
    }
}