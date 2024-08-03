using System;
using UnityEngine;

namespace Leopotam.EcsLite.PhysicsExtensions
{
    [Serializable]
    public struct CollisionEnterEvent
    {
        public GameObject source;
        public Collision collision;
    }
}