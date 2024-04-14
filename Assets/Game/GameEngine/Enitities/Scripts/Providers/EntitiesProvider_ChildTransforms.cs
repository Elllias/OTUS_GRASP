using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [AddComponentMenu("GameEngine/Entities Provider «Child Transforms»")]
    public sealed class EntitiesProvider_ChildTransforms : EntitiesProvider
    {
        public override IEnumerable<IEntity> ProvideEntities()
        {
            foreach (Transform child in this.transform)
            {
                if (child.TryGetComponent(out IEntity entity))
                {
                    yield return entity;
                }
            }
        }
    }
}