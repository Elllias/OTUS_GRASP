using System;
using UnityEngine;

namespace Lessons.Gameplay.CharacterInteraction
{
    public interface IComponent_CollisionEvents
    {
        event Action<Collision> OnCollisionEntered;

        event Action<Collision> OnCollisionStaying;

        event Action<Collision> OnCollisionExited;
    }
}