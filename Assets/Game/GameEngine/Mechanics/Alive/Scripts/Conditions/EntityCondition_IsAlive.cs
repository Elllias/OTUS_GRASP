using System;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EntityCondition_IsAlive : IEntityCondition
    {
        public bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_IsAlive component))
            {
                return component.IsAlive;
            }

            Debug.LogWarning("Component «Is Alive» is not found!");
            return default;
        }
    }
}