using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Effects/Effect Handler «Move Speed»")]
    public sealed class UEffectHandler_MoveSpeed : UEffectHandler
    {
        [SerializeField]
        private MonoFloatVariable speedMultiplier;
        
        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.MOVE_SPEED, out var multiplier))
            {
                this.speedMultiplier.Multiply(multiplier);
            }
        }

        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.MOVE_SPEED, out var multiplier))
            {
                this.speedMultiplier.Divide(multiplier);
            }
        }
    }
}