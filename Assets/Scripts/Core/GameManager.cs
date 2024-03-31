using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Enum;
using Interface;
using UnityEngine;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Core
{
    public class GameManager : IStartable
    {
        private IStartListener[] _startListeners;
        private IPauseListener[] _pauseListeners;
        private IResumeListener[] _resumeListeners;
        private IFinishListener[] _finishListeners;
        
        private EGameState _gameState;
        
        public void Start()
        {
            _startListeners = Object.FindObjectsOfType<MonoBehaviour>(true).OfType<IStartListener>().ToArray();
            _pauseListeners = Object.FindObjectsOfType<MonoBehaviour>(true).OfType<IPauseListener>().ToArray();
            _resumeListeners = Object.FindObjectsOfType<MonoBehaviour>(true).OfType<IResumeListener>().ToArray();
            _finishListeners = Object.FindObjectsOfType<MonoBehaviour>(true).OfType<IFinishListener>().ToArray();
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