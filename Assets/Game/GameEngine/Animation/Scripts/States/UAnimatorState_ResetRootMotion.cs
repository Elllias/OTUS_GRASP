using Elementary;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [AddComponentMenu("GameEngine/Animation/Animator State «Reset Root Motion»")]
    public sealed class UAnimatorState_ResetRootMotion : MonoState
    {
        [SerializeField]
        private UAnimatorMachine system;

        [Space]
        [SerializeField]
        private bool resetPosition = true;

        [SerializeField]
        private bool resetRotation = true;
        
        public override void Enter()
        {
            this.system.ResetRootMotion(
                resetPosition: this.resetPosition,
                resetRotation: this.resetRotation
            );
        }
    }
}