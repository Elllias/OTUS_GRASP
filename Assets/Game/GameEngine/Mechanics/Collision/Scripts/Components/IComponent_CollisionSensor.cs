using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_CollisionSensor
    {
        event Action<Collision> OnCollisionEntered;

        event Action<Collision> OnCollisionStaying;

        event Action<Collision> OnCollisionExited;
    }
}