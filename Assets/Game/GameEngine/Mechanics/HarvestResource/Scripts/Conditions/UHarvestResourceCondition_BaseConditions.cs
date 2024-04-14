using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Condition «Base Conditions»")]
    public sealed class UHarvestResourceCondition_BaseConditions : UHarvestResourceCondition
    {
        [SerializeField]
        public MonoCondition[] conditions;
        
        public override bool IsTrue(HarvestResourceOperation operation)
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