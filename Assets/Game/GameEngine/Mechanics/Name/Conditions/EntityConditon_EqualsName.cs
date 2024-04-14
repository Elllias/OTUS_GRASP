using System;
using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class EntityConditon_EqualsName : IEntityCondition
    {
        [SerializeReference]
        public IValue<string> expectedName;

        public EntityConditon_EqualsName(IValue<string> expectedName)
        {
            this.expectedName = expectedName;
        }

        public EntityConditon_EqualsName()
        {
        }

        public bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_GetName component))
            {
                return this.expectedName.Current == component.Name;
            }

            Debug.LogWarning("Component «Get Name» is not found!");
            return default;
        }
    }
}