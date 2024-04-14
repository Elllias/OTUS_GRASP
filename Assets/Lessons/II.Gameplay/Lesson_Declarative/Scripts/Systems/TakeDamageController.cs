using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    public sealed class TakeDamageController : MonoBehaviour
    {
        [SerializeField]
        private MonoEntityStd unit;

        [Button]
        public void TakeDamage(int damage)
        {
            this.unit.Get<ITakeDamageComponent>().TakeDamage(damage);
        }
    }
}