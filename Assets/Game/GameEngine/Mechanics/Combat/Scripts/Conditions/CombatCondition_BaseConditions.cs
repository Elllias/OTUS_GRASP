using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatCondition_BaseConditions : ICondition<CombatOperation>
    {
        public ICondition[] conditions;

        public CombatCondition_BaseConditions(params ICondition[] conditions)
        {
            this.conditions = conditions;
        }

        public bool IsTrue(CombatOperation value)
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue())
                {
                    return false;
                }
            }

            return true;
        }
    }
}