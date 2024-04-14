using UnityEngine;

namespace Declarative
{
    public interface IAwakeListener : IMonoElement
    {
        void Awake();
    }

    public interface IEnableListener : IMonoElement
    {
        void OnEnable();
    }

    public interface IStartListener : IMonoElement
    {
        void Start();
    }

    public interface IFixedUpdateListener : IMonoElement
    {
        void FixedUpdate(float deltaTime);
    }

    public interface IUpdateListener : IMonoElement
    {
        void Update(float deltaTime);
    }

    public interface ILateUpdateListener : IMonoElement
    {
        void LateUpdate(float deltaTime);
    }

    public interface IDisableListener : IMonoElement
    {
        void OnDisable();
    }

    public interface IDestroyListener : IMonoElement
    {
        void OnDestroy();
    }

    public interface IMonoInjective : IMonoElement
    {
        MonoBehaviour Context { set; }
    }

    public interface IMonoElement
    {
    }
}