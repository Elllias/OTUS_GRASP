using System;
using Elementary;

namespace Game.GameEngine.Animation
{
    [Serializable]
    public sealed class AnimatorState_ApplyRootMotion : State
    {
        private AnimatorMachine system;

        public void ConstructMachine(AnimatorMachine system)
        {
            this.system = system;
        }

        public override void Enter()
        {
            this.system.ApplyRootMotion();
        }
    }
}