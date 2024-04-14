using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/TakeDamage/Take Damage Mechanics «Play Animation»")]
    public sealed class UTakeDamageMechanics_PlayAnimation : UTakeDamageMechanics
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