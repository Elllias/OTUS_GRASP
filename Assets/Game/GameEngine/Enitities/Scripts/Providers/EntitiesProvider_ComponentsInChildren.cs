using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [AddComponentMenu("GameEngine/Entities Provider «Components In Children»")]
    public sealed class EntitiesProvider_ComponentsInChildren : EntitiesProvider
    {
        public override IEnumerable<IEntity> ProvideEntities()
        {
            return this.GetComponentsInChildren<IEntity>();
        }
    }
}