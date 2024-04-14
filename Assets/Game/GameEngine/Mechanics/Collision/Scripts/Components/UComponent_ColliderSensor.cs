using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Collision/Component «Collider Sensor»")]
    public sealed class UComponent_ColliderSensor : MonoBehaviour, IComponent_ColliderSensor
    {
        public event Action OnCollisionsUpdated
        {
            add { this.sensor.OnCollidersUpdated += value; }
            remove { this.sensor.OnCollidersUpdated -= value; }
        }

        [SerializeField]
        private ColliderDetection sensor;
        
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