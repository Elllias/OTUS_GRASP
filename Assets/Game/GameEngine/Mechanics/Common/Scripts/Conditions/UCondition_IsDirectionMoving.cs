using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Direction Moving»")]
    public sealed class UCondition_IsDirectionMoving : MonoCondition
    {
        [SerializeField]
        public UMoveInDirectionMotor engine;

        public override bool IsTrue()
        {
            return this.engine.IsMoving;
        }
    }
}