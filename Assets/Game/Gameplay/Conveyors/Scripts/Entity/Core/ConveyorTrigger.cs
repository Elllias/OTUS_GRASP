using System;
using Entities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class ConveyorTrigger : MonoBehaviour
    {
        public IEntity Conveyor { get; private set; }

        public ZoneType Zone
        {
            get { return this.zone; }
        }

        [SerializeField]
        private ZoneType zone;

        public void Setup(IEntity conveyor)
        {
            this.Conveyor = conveyor;
        }

        [Serializable]
        public enum ZoneType
        {
            LOAD = 0,
            UNLOAD = 1
        }
    }
}