using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class DestroyMechanics_PlayAnimation : DestroyMechanics
    {
        [SerializeField]
        public Animator animator;

        [SerializeField]
        public string animationName = "Destroy";

        protected override void Destroy(DestroyArgs destroyArgs)
        {
            this.animator.Play(this.animationName, -1, 0);
        }
    }
}