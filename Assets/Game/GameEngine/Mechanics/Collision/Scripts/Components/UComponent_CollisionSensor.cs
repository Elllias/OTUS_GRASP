using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Collision/Component «Collision Sensor»")]
    public sealed class UComponent_CollisionSensor : MonoBehaviour, IComponent_CollisionSensor
    {
        public event Action<Collision> OnCollisionEntered
        {
            add { this.eventReceiver.OnCollisionEntered += value; }
            remove { this.eventReceiver.OnCollisionEntered -= value; }
        }

        public event Action<Collision> OnCollisionStaying
        {
            add { this.eventReceiver.OnCollisionStaying += value; }
            remove { this.eventReceiver.OnCollisionStaying -= value; }
        }

        public event Action<Collision> OnCollisionExited
        {
            add { this.eventReceiver.OnCollisionExited += value; }
            remove { this.eventReceiver.OnCollisionExited -= value; }
        }

        [SerializeField]
        private CollisionSensor eventReceiver;
    }
}