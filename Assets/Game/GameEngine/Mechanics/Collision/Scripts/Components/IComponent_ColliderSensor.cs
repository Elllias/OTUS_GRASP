using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_ColliderSensor
    {
        event Action OnCollisionsUpdated;

        void GetCollidersNonAlloc(Collider[] buffer, out int size);

        void GetCollidersUnsafe(out Collider[] buffer, out int size);
    }
}