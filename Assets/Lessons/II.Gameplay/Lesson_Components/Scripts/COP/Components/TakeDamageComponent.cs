using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class TakeDamageComponent : MonoBehaviour, ITakeDamageComponent
    {
        public void TakeDamage(int damage)
        {
            this.takeDamageReceiver.Call(damage);
        }

        [SerializeField]
        private IntEventReceiver takeDamageReceiver;
    }
}