using UnityEngine;

namespace Entities
{
    [AddComponentMenu("Entities/Entity Proxy")]
    public sealed class MonoEntityProxy : MonoEntity
    {
        [SerializeField]
        public MonoEntity entity;

        public override T Get<T>()
        {
            return this.entity.Get<T>();
        }

        public override object[] GetAll()
        {
            return this.entity.GetAll();
        }

        public override bool TryGet<T>(out T element)
        {
            return this.entity.TryGet(out element);
        }
    }
}