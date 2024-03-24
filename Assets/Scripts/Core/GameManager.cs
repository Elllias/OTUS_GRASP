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
        
        private IStartListener[] _startListeners;
        private IUpdateListener[] _updateListeners;
        private IPauseListener[] _pauseListeners;
        private IResumeListener[] _resumeListeners;
        private IFinishListener[] _finishListeners;
        
        private EGameState _gameState;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            
            _startListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IStartListener>().ToArray();
            _updateListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IUpdateListener>().ToArray();
            _pauseListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IPauseListener>().ToArray();
            _resumeListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IResumeListener>().ToArray();
            _finishListeners = FindObjectsOfType<MonoBehaviour>(true).OfType<IFinishListener>().ToArray();
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
            Time.timeScale = 1f;
            
            for (var i = 0; i < _startListeners.Length; i++)
            {
                _startListeners[i].OnStart();
            }
            
            _gameState = EGameState.Playing;
        }
        
        public void FinishGame()
        {
            Time.timeScale = 0f;
            
            for (var i = 0; i < _finishListeners.Length; i++)
            {
                _finishListeners[i].OnFinish();
            }
            
            _gameState = EGameState.Finished;
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            
            for (var i = 0; i < _pauseListeners.Length; i++)
            {
                _pauseListeners[i].OnPause();
            }

            _gameState = EGameState.Stopping;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            
            for (var i = 0; i < _resumeListeners.Length; i++)
            {
                _resumeListeners[i].OnResume();
            }

            _gameState = EGameState.Playing;
        }

        public EGameState GetGameState()
        {
            return _gameState;
        }
    }
}