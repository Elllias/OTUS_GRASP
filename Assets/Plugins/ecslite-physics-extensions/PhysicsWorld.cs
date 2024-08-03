using Leopotam.EcsLite.Events;
using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    public static class PhysicsWorld
    {
        private static EcsEmitter<TriggerEnterEvent> _triggerEnterEmitter;
        private static EcsEmitter<TriggerExitEvent> _triggerExitEmitter;
        private static EcsEmitter<CollisionEnterEvent> _collisionEnterEmitter;
        private static EcsEmitter<CollisionExitEvent> _collisionExitEmitter;

        //Don't forget initialize world
        public static void Initialize(EcsWorld world)
        {
            _triggerEnterEmitter = new EcsEmitter<TriggerEnterEvent>(world);
        }

        internal static void OnTriggerEnter(GameObject source, Collider collider, bool enqueue = false)
        {
            var triggerEvent = new TriggerEnterEvent
            {
                source = source,
                collider = collider
            };

            if (enqueue)
            {
                _triggerEnterEmitter.EnqueueEvent(triggerEvent);
            }
            else
            {
                _triggerEnterEmitter.InvokeEvent(triggerEvent);
            }
        }

        internal static void OnTriggerExit(GameObject source, Collider collider, bool enqueue = false)
        {
            var triggerEvent = new TriggerExitEvent
            {
                source = source,
                collider = collider
            };
            
            if (enqueue)
            {
                _triggerExitEmitter.EnqueueEvent(triggerEvent);
            }
            else
            {
                _triggerExitEmitter.InvokeEvent(triggerEvent);
            }
        }

        internal static void OnCollisionEnter(GameObject source, Collision collision, bool enqueue = false)
        {
            var collisionEvent = new CollisionEnterEvent
            {
                source = source,
                collision = collision
            };

            if (enqueue)
            {
                _collisionEnterEmitter.EnqueueEvent(collisionEvent);
            }
            else
            {
                _collisionEnterEmitter.InvokeEvent(collisionEvent);
            }
        }

        internal static void OnCollisionExit(GameObject source, Collision collision, bool enqueue = false)
        {
            var collisionEvent = new CollisionExitEvent
            {
                source = source,
                collision = collision
            };

            if (enqueue)
            {
                _collisionExitEmitter.EnqueueEvent(collisionEvent);
            }
            else
            {
                _collisionExitEmitter.InvokeEvent(collisionEvent);
            }
        }
    }
}