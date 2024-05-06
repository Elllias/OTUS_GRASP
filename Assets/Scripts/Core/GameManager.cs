using System;
using System.Collections.Generic;
using System.Linq;
using Character;
using Enum;
using Interface;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Core
{
    public class GameManager
    {
        private readonly List<IStartListener> _startListeners = new();
        private readonly List<IPauseListener> _pauseListeners = new();
        private readonly List<IResumeListener> _resumeListeners = new();
        private readonly List<IFinishListener> _finishListeners = new();
        
        private EGameState _gameState;

        public void AddPauseListener(IPauseListener pauseListener)
        {
            _pauseListeners.Add(pauseListener);
        }
        
        public void AddResumeListener(IResumeListener resumeListener)
        {
            _resumeListeners.Add(resumeListener);
        }
        
        public void AddFinishListener(IFinishListener finishListener)
        {
            _finishListeners.Add(finishListener);
        }
        
        public void AddStartListener(IStartListener startListener)
        {
            _startListeners.Add(startListener);
        }
        
        public void RemovePauseListener(IPauseListener pauseListener)
        {
            _pauseListeners.Remove(pauseListener);
        }
        
        public void RemoveResumeListener(IResumeListener resumeListener)
        {
            _resumeListeners.Remove(resumeListener);
        }
        
        public void RemoveFinishListener(IFinishListener finishListener)
        {
            _finishListeners.Remove(finishListener);
        }
        
        public void RemoveStartListener(IStartListener startListener)
        {
            _startListeners.Remove(startListener);
        }
        
        public void StartGame()
        {
            Time.timeScale = 1f;
            
            for (var i = 0; i < _startListeners.Count; i++)
            {
                _startListeners[i].OnStart();
            }
            
            _gameState = EGameState.Playing;
        }
        
        public void FinishGame()
        {
            Time.timeScale = 0f;
            
            for (var i = 0; i < _finishListeners.Count; i++)
            {
                _finishListeners[i].OnFinish();
            }
            
            _gameState = EGameState.Finished;
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
            
            for (var i = 0; i < _pauseListeners.Count; i++)
            {
                _pauseListeners[i].OnPause();
            }

            _gameState = EGameState.Stopping;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1f;
            
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
    }
}