using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat Condition «Base Conditions»")]
    public sealed class UCombatCondition_BaseConditions : UCombatCondition
    {
        [SerializeField]
        public MonoCondition[] conditions;
        
        public override bool IsTrue(CombatOperation operation)
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