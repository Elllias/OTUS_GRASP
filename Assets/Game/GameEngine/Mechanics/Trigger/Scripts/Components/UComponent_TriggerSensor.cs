using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Trigger/Component «Trigger Sensor»")]
    public sealed class UComponent_TriggerSensor : MonoBehaviour, IComponent_TriggerSensor
    {
        public event Action<Collider> OnEntered
        {
            add { this.eventReceiver.OnTriggerEntered += value; }
            remove { this.eventReceiver.OnTriggerEntered -= value; }
        }

        public event Action<Collider> OnStaying
        {
            add { this.eventReceiver.OnTriggerStaying += value; }
            remove { this.eventReceiver.OnTriggerStaying -= value; }
        }

        public event Action<Collider> OnExited
        {
            add { this.eventReceiver.OnTriggerExited += value; }
            remove { this.eventReceiver.OnTriggerExited -= value; }
        }

        [SerializeField]
        private TriggerSensor eventReceiver;
    }
}