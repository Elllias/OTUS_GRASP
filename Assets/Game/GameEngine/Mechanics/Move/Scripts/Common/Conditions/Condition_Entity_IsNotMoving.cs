using Entities;
using UnityEngine;
using ICondition = Elementary.ICondition;

namespace Game.GameEngine.Mechanics
{
    public sealed class Condition_Entity_IsNotMoving : ICondition
    {
        private readonly IComponent_IsMoving moveComponent;

        public Condition_Entity_IsNotMoving(IEntity entity)
        {
            this.moveComponent = entity.Get<IComponent_IsMoving>();
        }

        public bool IsTrue()
        {
            return !this.moveComponent.IsMoving;
        }
    }
}