using System;
using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    [Serializable]
    public struct CollisionExitEvent
    {
        public GameObject source;
        public Collision collision;
    }
}