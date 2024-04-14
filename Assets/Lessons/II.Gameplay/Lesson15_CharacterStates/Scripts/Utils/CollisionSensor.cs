using Lessons.Utils;
using UnityEngine;

namespace Lessons.Gameplay.Interaction
{
    public sealed class CollisionSensor : MonoBehaviour
    {
        public AtomicEvent<Collision> OnEntered = new();
        public AtomicEvent<Collision> OnExited = new();

        private void OnCollisionEnter(Collision collision)
        {
            this.OnEntered?.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            this.OnExited?.Invoke(collision);
        }
    }
}