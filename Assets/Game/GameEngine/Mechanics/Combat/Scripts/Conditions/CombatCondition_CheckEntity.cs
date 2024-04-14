using System.Collections.Generic;
using Elementary;
using Entities;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatCondition_CheckEntity : ICondition<CombatOperation>
    {
        public IEnumerable<IEntityCondition> conditions;

        public CombatCondition_CheckEntity(IEnumerable<IEntityCondition> conditions)
        {
            this.conditions = conditions;
        }

        public bool IsTrue(CombatOperation operation)
        {
            var targetEntity = operation.targetEntity;
            foreach (var condition in conditions)
            {
                if (!condition.IsTrue(targetEntity))
                {
                    return false;
                }
            }


            return true;
        }
    }
}