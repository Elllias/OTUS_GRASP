using System.Collections.Generic;
using Elementary;
using Entities;

namespace Game.GameEngine.Mechanics
{
    public sealed class HarvestResourceCondition_CheckEntity : ICondition<HarvestResourceOperation>
    {
        public IEnumerable<IEntityCondition> conditions;

        public HarvestResourceCondition_CheckEntity(IEnumerable<IEntityCondition> conditions)
        {
            this.conditions = conditions;
        }

        public bool IsTrue(HarvestResourceOperation operation)
        {
            var targetEntity = operation.targetResource;
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