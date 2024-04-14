using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.App
{
    public sealed class AnalyticsManager : MonoBehaviour
    {
        private static AnalyticsManager instance;

        private IAnalyticsLogger logger;

        public static void LogEvent(string eventKey, params AnalyticsParameter[] parameters)
        {
            if (instance != null)
            {
                instance.LogEventInternal(eventKey, parameters);
            }
        }

        [PropertySpace(12)]
        [ShowIf("debugLog")]
        [GUIColor("debugColor")]
        [Button("Log Event")]
        private void LogEventInternal(string eventKey, params AnalyticsParameter[] parameters)
        {
#if UNITY_EDITOR
            if (this.debugLog)
            {
                this.logger.LogEvent(eventKey, parameters);
            }
#else
            this.logger.LogEvent(eventKey, parameters);
#endif
        }

        private void Awake()
        {
            if (instance != null)
            {
                throw new Exception("Analytics Manager is already created!");
            }

            instance = this;

#if UNITY_EDITOR
            this.logger = new DebugAnalyticsLogger(this.debugColor);
#else
            this.logger = new ReleaseAnalyticsLogger();
#endif
        }

        private void OnDestroy()
        {
            instance = null;
        }

#if UNITY_EDITOR
        [SerializeField]
        private bool debugLog;

        [ShowIf("debugLog")]
        [SerializeField]
        private Color debugColor;

        private void OnValidate()
        {
            this.logger = new DebugAnalyticsLogger(this.debugColor);
        }
#endif
    }
}