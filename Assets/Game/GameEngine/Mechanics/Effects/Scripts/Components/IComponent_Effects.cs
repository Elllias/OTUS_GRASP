using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_GetEffect
    {
        IEffect Effect { get; }
    }

    public interface IComponent_Effector
    {
        event Action<IEffect> OnApplied;
        event Action<IEffect> OnDiscarded;
        
        void Apply(IEffect effect);
        void Discard(IEffect effect);
    }
}