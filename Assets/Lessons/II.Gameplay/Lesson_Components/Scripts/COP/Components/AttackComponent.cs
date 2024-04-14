using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class AttackComponent : MonoBehaviour, IAttackComponent
    {
        [SerializeField]
        private EntityEventReceiver attackReceiver;
    
        [Button]
        public void Attack(Entity target)
        {
            this.attackReceiver.Call(target);
        }
    }
}