using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity")]
    public class MonoEntityStd : MonoEntity, ISerializationCallbackReceiver
    {
        [Space]
        [SerializeField]
        private List<MonoBehaviour> monoElements = new();

        [Space]
        [SerializeField]
        private List<ScriptableObject> scriptableElements = new();

        [Space]
        [SerializeReference]
        private List<object> referenceElements = new();

        private ListEntity entity;

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

        public virtual void OnAfterDeserialize()
        {
            var allElements = new List<object>();
            allElements.AddRange(this.monoElements);
            allElements.AddRange(this.scriptableElements);
            allElements.AddRange(this.referenceElements);
            this.entity = new ListEntity(allElements);
        }

        public virtual void OnBeforeSerialize()
        {
        }
    }
}