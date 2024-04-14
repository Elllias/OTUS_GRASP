using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.App
{
    public sealed class ApplicationManager : MonoBehaviour
    {
        public event Action<float> OnUpdate;

        public event Action OnPaused;

        public event Action OnResumed;

        public event Action OnQuit;

        private readonly List<IAppUpdateListener> updateListeners = new();

        private readonly List<IAppPauseListener> pauseListeners = new();

        private readonly List<IAppResumeListener> resumeListeners = new();

        private readonly List<IAppQuitListener> quitListeners = new();

        private void Update()
        {
            this.InvokeUpdate();
        }

#if UNITY_EDITOR
        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                this.InvokeResume();
            }
            else
            {
                this.InvokePause();
            }
        }

#else
        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                this.InvokePause();
            }
            else
            {
                this.InvokeResume();
            }
        }
#endif

        private void OnApplicationQuit()
        {
            this.InvokeQuit();
        }
        
        public void AddListener(object listener)
        {
            if (listener is IAppUpdateListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }

            if (listener is IAppPauseListener pauseListener)
            {
                this.pauseListeners.Add(pauseListener);
            }
            
            if (listener is IAppResumeListener resumeListener)
            {
                this.resumeListeners.Add(resumeListener);
            }

            if (listener is IAppQuitListener quitListener)
            {
                this.quitListeners.Add(quitListener);
            }
        }
        
        public void RemoveListener(object listener)
        {
            if (listener is IAppUpdateListener updateListener)
            {
                this.updateListeners.Remove(updateListener);
            }

            if (listener is IAppPauseListener pauseListener)
            {
                this.pauseListeners.Remove(pauseListener);
            }
            
            if (listener is IAppResumeListener resumeListener)
            {
                this.resumeListeners.Remove(resumeListener);
            }

            if (listener is IAppQuitListener quitListener)
            {
                this.quitListeners.Remove(quitListener);
            }
        }

        private void InvokeUpdate()
        {
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime);
            }

            this.OnUpdate?.Invoke(deltaTime);
        }

        private void InvokePause()
        {
            for (int i = 0, count = this.pauseListeners.Count; i < count; i++)
            {
                var listener = this.pauseListeners[i];
                listener.OnPaused();
            }

            this.OnPaused?.Invoke();
        }

        private void InvokeResume()
        {
            for (int i = 0, count = this.resumeListeners.Count; i < count; i++)
            {
                var listener = this.resumeListeners[i];
                listener.OnResumed();
            }

            this.OnResumed?.Invoke();
        }

        private void InvokeQuit()
        {
            for (int i = 0, count = this.quitListeners.Count; i < count; i++)
            {
                var listener = this.quitListeners[i];
                listener.OnQuit();
            }

            this.OnQuit?.Invoke();
        }
    }
}