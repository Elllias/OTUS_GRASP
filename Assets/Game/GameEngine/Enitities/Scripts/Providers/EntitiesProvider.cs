using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public abstract class EntitiesProvider : MonoBehaviour
    {
        public abstract IEnumerable<IEntity> ProvideEntities();
    }
}