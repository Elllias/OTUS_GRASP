using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [AddComponentMenu("GameEngine/Entities Provider «Base»")]
    public sealed class EntitiesProvider_Base : EntitiesProvider
    {
        [SerializeField]
        private MonoEntity[] entities;
        
        public override IEnumerable<IEntity> ProvideEntities()
        {
            return this.entities;
        }
    }
}