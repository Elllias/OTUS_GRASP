using System;
using System.Collections.Generic;
using UnityEngine;

namespace Declarative
{
    public abstract class DeclarativeModel : MonoBehaviour
    {
        private Dictionary<Type, object> sections;

        private MonoContext monoContext;

        public Action onAwake;
        public Action onEnable;
        public Action onStart;
        public Action<float> onUpdate;
        public Action<float> onFixedUpdate;
        public Action<float> onLateUpdate;
        public Action onDisable;
        public Action onDestroy;

        internal object GetSection(Type type)
        {
            return this.sections[type];
        }

        internal bool TryGetSection(Type type, out object section)
        {
            return this.sections.TryGetValue(type, out section);
        }

        private void Awake()
        {
            this.onAwake = null;
            this.onEnable = null;
            this.onStart = null;
            this.onUpdate = null;
            this.onFixedUpdate = null;
            this.onLateUpdate = null;
            this.onDisable = null;
            this.onDestroy = null;

            this.monoContext = new MonoContext(this);
            this.sections = SectionScanner.ScanSections(this);

            foreach (var section in this.sections.Values)
            {
                MonoContextInstaller.InstallElements(section, this.monoContext);
                SectionConstructor.ConstructSection(section, this);
            }

            this.monoContext.Awake();
            this.onAwake?.Invoke();
        }

        private void OnEnable()
        {
            this.monoContext.OnEnable();
            this.onEnable?.Invoke();
        }

        private void Start()
        {
            this.monoContext.Start();
            this.onStart?.Invoke();
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            this.monoContext.FixedUpdate(deltaTime);
            this.onFixedUpdate?.Invoke(deltaTime);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            this.monoContext.Update(deltaTime);
            this.onUpdate?.Invoke(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            this.monoContext.LateUpdate(deltaTime);
            this.onLateUpdate?.Invoke(deltaTime);
        }

        private void OnDisable()
        {
            this.monoContext.OnDisable();
            this.onDisable?.Invoke();
        }

        private void OnDestroy()
        {
            this.monoContext.OnDestroy();
            this.onDestroy?.Invoke();
        }

#if UNITY_EDITOR
        [ContextMenu("Construct")]
        private void Construct()
        {
            this.Awake();
            this.OnEnable();
            Debug.Log($"<color=#FF6235>: {this.name} successfully constructed!</color>");
        }

        [ContextMenu("Destruct")]
        private void Destruct()
        {
            if (this.monoContext != null)
            {
                this.monoContext.OnDisable();
                this.monoContext.OnDestroy();
            }

            Debug.Log($"<color=#FF6235>: {this.name} successfully destructed!</color>");
        }
#endif
    }
}