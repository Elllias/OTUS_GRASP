using System;
using Game.GameEngine.Mechanics;

namespace Game.GameEngine
{
    public interface IComponent_TakeDamage
    {
        void TakeDamage(TakeDamageArgs damageArgs);
    }

    public interface IComponent_OnDamageTaken
    {
        event Action<TakeDamageArgs> OnDamageTaken;
    }
}