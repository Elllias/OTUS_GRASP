using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Enum;
using Interface;
using UnityEngine;

namespace Core
{
    public sealed class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        private List<IStartListener> _startListeners;
        private List<IUpdateListener> _updateListeners;
        private List<IPauseListener> _pauseListeners;
        private List<IResumeListener> _resumeListeners;
        private List<IFinishListener> _finishListeners;
        
        private EGameState _gameState;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            
            _startListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IStartListener>().ToList();
            _updateListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IUpdateListener>().ToList();
            _pauseListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IPauseListener>().ToList();
            _resumeListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IResumeListener>().ToList();
            _finishListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IFinishListener>().ToList();
        }

        public void Update()
        {
            if (_gameState != EGameState.Playing) return;
            
            foreach (var listener in _updateListeners)
            {
                listener.OnUpdate();
            }
        }
        
        public void StartGame()
        {
            for (var i = 0; i < _startListeners.Count; i++)
            {
                _startListeners[i].OnStart();
            }
            
            _gameState = EGameState.Playing;
        }
        
        public void FinishGame()
        {
            for (var i = 0; i < _finishListeners.Count; i++)
            {
                _finishListeners[i].OnFinish();
            }
            
            _gameState = EGameState.Finished;
        }

        public void PauseGame()
        {
            for (var i = 0; i < _pauseListeners.Count; i++)
            {
                _pauseListeners[i].OnPause();
            }

            _gameState = EGameState.Stopping;
        }

        public void ResumeGame()
        {
            for (var i = 0; i < _resumeListeners.Count; i++)
            {
                _resumeListeners[i].OnResume();
            }

            _gameState = EGameState.Playing;
        }

        public EGameState GetGameState()
        {
            return _gameState;
        }

        public void AddPauseListener(IPauseListener pauseListener)
        {
            _pauseListeners.Add(pauseListener);
        }

        public void RemovePauseListener(IPauseListener pauseListener)
        {
            _pauseListeners.Remove(pauseListener);
        }
        
        public void AddResumeListener(IResumeListener resumeListener)
        {
            _resumeListeners.Add(resumeListener);
        }
        
        public void RemoveResumeListener(IResumeListener resumeListener)
        {
            _resumeListeners.Remove(resumeListener);
        }
        
        public void AddFinishListener(IFinishListener finishListener)
        {
            _finishListeners.Add(finishListener);
        }
        
        public void RemoveFinishListener(IFinishListener finishListener)
        {
            _finishListeners.Remove(finishListener);
        }
        
        public void AddStartListener(IStartListener startListener)
        {
            _startListeners.Add(startListener);
        }
        
        public void RemoveStartListener(IStartListener startListener)
        {
            _startListeners.Remove(startListener);
        }
    }
}