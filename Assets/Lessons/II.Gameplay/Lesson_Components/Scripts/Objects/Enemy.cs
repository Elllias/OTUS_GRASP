using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField]
        private IntEventReceiver takeDamageReceiver;

        [SerializeField]
        private Vector3EventReceiver moveReceiver;

        public void TakeDamage(int damage)
        {
            this.takeDamageReceiver.Call(damage);
        }

        public void Move(Vector3 vector)
        {
            this.moveReceiver.Call(vector);
        }
    }
}