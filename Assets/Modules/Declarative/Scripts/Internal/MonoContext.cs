using System.Collections.Generic;
using UnityEngine;

namespace Declarative
{
    internal sealed class MonoContext
    {
        private readonly MonoBehaviour root;
        
        private readonly List<IAwakeListener> awakeComponents = new();

        private readonly List<IEnableListener> enableComponents = new();

        private readonly List<IStartListener> startComponents = new();

        private readonly List<IFixedUpdateListener> fixedUpdateComponents = new();

        private readonly List<IUpdateListener> updateComponents = new();

        private readonly List<ILateUpdateListener> lateUpdateComponents = new();

        private readonly List<IDisableListener> disableComponents = new();

        private readonly List<IDestroyListener> destroyComponents = new();

        public MonoContext(MonoBehaviour root)
        {
            this.root = root;
        }

        internal void AddListener(IMonoElement element)
        {
            if (element is IMonoInjective injectiveComponent)
            {
                injectiveComponent.Context = this.root;
            }
            
            if (element is IAwakeListener awakeComponent)
            {
                this.awakeComponents.Add(awakeComponent);
            }

            if (element is IEnableListener enableComponent)
            {
                this.enableComponents.Add(enableComponent);
            }

            if (element is IStartListener startComponent)
            {
                this.startComponents.Add(startComponent);
            }

            if (element is IFixedUpdateListener fixedUpdateComponent)
            {
                this.fixedUpdateComponents.Add(fixedUpdateComponent);
            }

            if (element is IUpdateListener updateComponent)
            {
                this.updateComponents.Add(updateComponent);
            }

            if (element is ILateUpdateListener lateUpdateComponent)
            {
                this.lateUpdateComponents.Add(lateUpdateComponent);
            }

            if (element is IDisableListener disableComponent)
            {
                this.disableComponents.Add(disableComponent);
            }
        }

        public void Awake()
        {
            for (int i = 0, count = this.awakeComponents.Count; i < count; i++)
            {
                var listener = this.awakeComponents[i];
                listener.Awake();
            }
        }

        public void OnEnable()
        {
            for (int i = 0, count = this.enableComponents.Count; i < count; i++)
            {
                var listener = this.enableComponents[i];
                listener.OnEnable();
            }
        }

        public void Start()
        {
            for (int i = 0, count = this.startComponents.Count; i < count; i++)
            {
                var listener = this.startComponents[i];
                listener.Start();
            }
        }

        public void FixedUpdate(float deltaTime)
        {
            for (int i = 0, count = this.fixedUpdateComponents.Count; i < count; i++)
            {
                var listener = this.fixedUpdateComponents[i];
                listener.FixedUpdate(deltaTime);
            }
        }

        public void Update(float deltaTime)
        {
            for (int i = 0, count = this.updateComponents.Count; i < count; i++)
            {
                var listener = this.updateComponents[i];
                listener.Update(deltaTime);
            }
        }

        public void LateUpdate(float deltaTime)
        {
            for (int i = 0, count = this.lateUpdateComponents.Count; i < count; i++)
            {
                var listener = this.lateUpdateComponents[i];
                listener.LateUpdate(deltaTime);
            }
        }

        public void OnDisable()
        {
            for (int i = 0, count = this.disableComponents.Count; i < count; i++)
            {
                var listener = this.disableComponents[i];
                listener.OnDisable();
            }
        }

        public void OnDestroy()
        {
            for (int i = 0, count = this.destroyComponents.Count; i < count; i++)
            {
                var listener = this.destroyComponents[i];
                listener.OnDestroy();
            }
        }
    }
}