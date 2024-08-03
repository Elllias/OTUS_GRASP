using System;
using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    [Serializable]
    public struct TriggerEnterEvent
    {
        public GameObject source;
        public Collider collider;
    }
}