using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    internal sealed class CollisionDispatcher : MonoBehaviour
    {
        [SerializeField]
        private bool enqueueEvents = true;
        
        private void OnCollisionEnter(Collision collision)
        {
            PhysicsWorld.OnCollisionEnter(this.gameObject, collision, this.enqueueEvents);
        }

        private void OnCollisionExit(Collision collision)
        {
            PhysicsWorld.OnCollisionExit(this.gameObject, collision, this.enqueueEvents);
        }
    }
}