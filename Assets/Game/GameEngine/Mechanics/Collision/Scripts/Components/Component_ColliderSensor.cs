using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_ColliderSensor : IComponent_ColliderSensor
    {
        public event Action OnCollisionsUpdated
        {
            add { this.sensor.OnCollidersUpdated += value; }
            remove { this.sensor.OnCollidersUpdated -= value; }
        }

        private readonly ColliderDetection sensor;

        public Component_ColliderSensor(ColliderDetection sensor)
        {
            this.sensor = sensor;
        }

        public void GetCollidersNonAlloc(Collider[] buffer, out int size)
        {
            this.sensor.GetCollidersNonAlloc(buffer, out size);
        }

        public void GetCollidersUnsafe(out Collider[] buffer, out int size)
        {
            this.sensor.GetCollidersUnsafe(out buffer, out size);
        }
    }
}