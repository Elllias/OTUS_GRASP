using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Effects/Effect Handler «Melee Damage»")]
    public sealed class UEffectHandler_MeleeDamage : UEffectHandler
    {
        [SerializeField]
        private MonoFloatVariable damageMultiplier;

        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                this.damageMultiplier.Multiply(multiplier);
            }
        }

        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                this.damageMultiplier.Divide(multiplier);
            }
        }
    }
}