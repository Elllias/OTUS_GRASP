using System;
using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    [Serializable]
    public struct TriggerExitEvent
    {
        public GameObject source;
        public Collider collider;
    }
}