using Entities;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatOperation
    {
        [ShowInInspector]
        public IEntity targetEntity;

        [ReadOnly]
        [ShowInInspector]
        public bool targetDestroyed;

        public CombatOperation(IEntity target)
        {
            this.targetEntity = target;
        }

        public CombatOperation()
        {
        }
    }
}