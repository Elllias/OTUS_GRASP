using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Combat»")]
    public sealed class UCondition_IsCombat : MonoCondition
    {
        [SerializeField]
        public UCombatOperator @operator;
        
        public override bool IsTrue()
        {
            return this.@operator.IsActive;
        }
    }
}