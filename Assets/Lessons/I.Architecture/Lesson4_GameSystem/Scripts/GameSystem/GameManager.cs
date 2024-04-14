using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public enum GameState
    {
        OFF = 0,
        PLAYING = 1,
        PAUSED = 2,
        FINISHED = 3
    }

    public sealed class GameManager : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public GameState State
        {
            get { return this.state; }
        }

        private GameState state;

        private readonly List<IGameListener> listeners = new();

        private readonly List<IGameUpdateListener> updateListeners = new();
        
        private readonly List<IGameFixedUpdateListener> fixedUpdateListeners = new();
        
        private readonly List<IGameLateUpdateListener> lateUpdateListeners = new();

        private void Update()
        {
            if (this.state != GameState.PLAYING)
            {
                return;
            }

            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }

        private void FixedUpdate()
        {
            if (this.state != GameState.PLAYING)
            {
                return;
            }
            
            var deltaTime = Time.fixedDeltaTime;
            for (int i = 0, count = this.fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = this.fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (this.state != GameState.PLAYING)
            {
                return;
            }
            
            var deltaTime = Time.deltaTime;
            for (int i = 0, count = this.lateUpdateListeners.Count; i < count; i++)
            {
                var listener = this.lateUpdateListeners[i];
                listener.OnLateUpdate(deltaTime);
            }
        }
        
        public void AddListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            this.listeners.Add(listener);

            if (listener is IGameUpdateListener updateListener)
            {
                this.updateListeners.Add(updateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                this.fixedUpdateListeners.Add(fixedUpdateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                this.lateUpdateListeners.Add(lateUpdateListener);
            }
        }


        public void RemoveListener(IGameListener listener)
        {
            if (listener == null)
            {
                return;
            }
            
            this.listeners.Remove(listener);

            if (listener is IGameUpdateListener updateListener)
            {
                this.updateListeners.Remove(updateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                this.fixedUpdateListeners.Remove(fixedUpdateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                this.lateUpdateListeners.Remove(lateUpdateListener);
            }
        }

        [Button]
        public void StartGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStartGame();
                }
            }

            this.state = GameState.PLAYING;
        }

        [Button]
        public void PauseGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPauseGame();
                }
            }
            
            this.state = GameState.PAUSED;
        }

        [Button]
        public void ResumeGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResumeGame();
                }
            }
            
            this.state = GameState.PLAYING;
        }

        [Button]
        public void FinishGame()
        {
            foreach (var listener in this.listeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinishGame();
                }
            }
            
            this.state = GameState.FINISHED;
        }
    }
}