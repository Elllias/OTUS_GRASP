using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Not Combat»")]
    public sealed class UCondition_IsNotCombat : MonoCondition
    {
        [SerializeField]
        public UCombatOperator @operator;
        
        public override bool IsTrue()
        {
            return !this.@operator.IsActive;
        }
    }
}