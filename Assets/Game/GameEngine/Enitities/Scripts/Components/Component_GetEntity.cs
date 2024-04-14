using Entities;

namespace Game.GameEngine.Enitities
{
    public sealed class Component_GetEntity : IComponent_GetEntity
    {
        public IEntity Entity { get; }

        public Component_GetEntity(IEntity entity)
        {
            this.Entity = entity;
        }
    }
}