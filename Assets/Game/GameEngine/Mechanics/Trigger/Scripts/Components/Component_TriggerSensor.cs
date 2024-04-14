using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_TriggerSensor : IComponent_TriggerSensor
    {
        public event Action<Collider> OnEntered
        {
            add { this.sensor.OnTriggerEntered += value; }
            remove { this.sensor.OnTriggerEntered -= value; }
        }

        public event Action<Collider> OnStaying
        {
            add { this.sensor.OnTriggerStaying += value; }
            remove { this.sensor.OnTriggerStaying -= value; }
        }

        public event Action<Collider> OnExited
        {
            add { this.sensor.OnTriggerExited += value; }
            remove { this.sensor.OnTriggerExited -= value; }
        }

        private readonly TriggerSensor sensor;

        public Component_TriggerSensor(TriggerSensor sensor)
        {
            this.sensor = sensor;
        }
    }
}