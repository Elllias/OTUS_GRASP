using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction Condition «Base Conditions»")]
    public sealed class UMoveInDirectionCondition_BaseConditions : UMoveInDirecitonCondition
    {
        [SerializeField]
        private MonoCondition[] conditions;
        
        public override bool IsTrue(Vector3 value)
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