using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class EffectHandler_MoveSpeed : IEffectHandler<IEffect>
    {
        private readonly IVariable<float> multiplier;

        public EffectHandler_MoveSpeed(IVariable<float> multiplier)
        {
            this.multiplier = multiplier;
        }

        void IEffectHandler<IEffect>.OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.MOVE_SPEED, out var multiplier))
            {
                this.multiplier.Current *= multiplier;
            }
        }

        void IEffectHandler<IEffect>.OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.MOVE_SPEED, out var multiplier))
            {
                this.multiplier.Current /= multiplier;
            }
        }
    }
}