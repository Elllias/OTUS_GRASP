using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_IsDestroyed
    {
        bool IsDestroyed { get; }
    }

    public interface IComponent_CanDestroy
    {
        bool CanDestroy();
    }

    public interface IComponent_Destoy
    {
        void Destroy();
    }

    public interface IComponent_OnDestroyed
    {
        event Action OnDestroyed;
    }

    public interface IComponent_Destroy<in T>
    {
        void Destroy(T args);
    }

    public interface IComponent_OnDestroyed<out T>
    {
        event Action<T> OnDestroyed;
    }
}