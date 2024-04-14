using System;
using Lessons.Gameplay.Interaction;
using UnityEngine;

namespace Lessons.Character.Components
{
    public interface ICollisionComponent
    {
        event Action<Collision> OnEntered;
        event Action<Collision> OnExited;
    }

    public sealed class CollisionComponent : ICollisionComponent
    {
        public event Action<Collision> OnEntered;
        public event Action<Collision> OnExited;

        public CollisionComponent(CollisionSensor sensor)
        {
            sensor.OnEntered += collision => this.OnEntered?.Invoke(collision);
            sensor.OnExited += collision => this.OnExited?.Invoke(collision);
        }
    }
}