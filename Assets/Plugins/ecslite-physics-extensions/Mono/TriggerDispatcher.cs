using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    internal sealed class TriggerDispatcher : MonoBehaviour
    {
        [SerializeField]
        private bool enqueueEvents = true;

        private void OnTriggerEnter(Collider collider)
        {
            PhysicsWorld.OnTriggerEnter(this.gameObject, collider, this.enqueueEvents);
        }

        private void OnTriggerExit(Collider collider)
        {
            PhysicsWorld.OnTriggerExit(this.gameObject, collider, this.enqueueEvents);
        }
    }
}
