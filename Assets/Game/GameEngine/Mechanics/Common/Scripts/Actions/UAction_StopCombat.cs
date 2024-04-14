using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Stop Combat»")]
    public sealed class UAction_StopCombat : MonoAction
    {
        [SerializeField]
        public UCombatOperator @operator;

        public override void Do()
        {
            if (this.@operator.IsActive)
            {
                this.@operator.Stop();
            }
        }
    }
}