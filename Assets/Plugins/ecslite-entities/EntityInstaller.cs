using UnityEngine;

namespace Leopotam.EcsLite.Entities
{
    public abstract class EntityInstaller : MonoBehaviour
    {
        protected internal abstract void Install(Entity entity);
        protected internal abstract void Dispose(Entity entity);
    }
}