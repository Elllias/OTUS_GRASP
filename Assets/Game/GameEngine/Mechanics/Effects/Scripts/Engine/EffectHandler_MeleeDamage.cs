using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class EffectHandler_MeleeDamage : IEffectHandler<IEffect>
    {
        private readonly IVariable<float> multiplier;

        public EffectHandler_MeleeDamage(IVariable<float> multiplier)
        {
            this.multiplier = multiplier;
        }

        void IEffectHandler<IEffect>.OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                this.multiplier.Current *= multiplier;
            }
        }

        void IEffectHandler<IEffect>.OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                this.multiplier.Current /= multiplier;
            }
        }
    }
}