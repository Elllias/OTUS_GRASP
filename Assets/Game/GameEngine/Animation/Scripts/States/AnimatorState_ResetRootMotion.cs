using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Animation
{
    [Serializable]
    public sealed class AnimatorState_ResetRootMotion : State
    {
        public bool resetPosition = true;

        public bool resetRotation = true;

        private AnimatorMachine system;

        public void ConstructMachine(AnimatorMachine system)
        {
            this.system = system;
        }

        public override void Enter()
        {
            this.system.ResetRootMotion(
                resetPosition: this.resetPosition,
                resetRotation: this.resetRotation
            );
        }
    }
}