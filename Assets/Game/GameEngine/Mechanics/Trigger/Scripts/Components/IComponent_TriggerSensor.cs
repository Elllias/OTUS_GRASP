using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_TriggerSensor
    {
        event Action<Collider> OnEntered;

        event Action<Collider> OnStaying; 

        event Action<Collider> OnExited;
    }
}