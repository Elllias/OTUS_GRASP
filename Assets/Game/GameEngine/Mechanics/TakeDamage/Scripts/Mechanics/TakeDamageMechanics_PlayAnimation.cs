using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class TakeDamageMechanics_PlayAnimation : TakeDamageMechanics
    {
        [SerializeField]
        public Animator animator;

        [SerializeField]
        public string animationName = "hit";

        protected override void OnDamageTaken(TakeDamageArgs damageArgs)
        {
            this.animator.Play(this.animationName, -1, 0);
        }
    }
}