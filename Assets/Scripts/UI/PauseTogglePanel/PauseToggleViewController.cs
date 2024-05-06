using System;
using Core;
using Enum;
using Interface;
using UnityEngine;
using VContainer;

namespace UI.PauseTogglePanel
{
    public class PauseToggleViewController : IStartListener, IFinishListener
    {
        private const string RESUME_TEXT = "Resume";
        private const string PAUSE_TEXT = "Pause";
        
        private readonly PauseToggleView _pauseToggleView;
        private readonly GameManager _gameManager;

        public PauseToggleViewController(PauseToggleView pauseToggleView, GameManager gameManager)
        {
            _pauseToggleView = pauseToggleView;
            _gameManager = gameManager;
            
            _pauseToggleView.GetButton().onClick.AddListener(OnToggleButtonClicked);
            
            _pauseToggleView.Hide();
            _pauseToggleView.SetText(PAUSE_TEXT);
            
            _gameManager.AddStartListener(this);
            _gameManager.AddFinishListener(this);
        }

        ~PauseToggleViewController()
        {
            _gameManager.RemoveStartListener(this);
            _gameManager.RemoveFinishListener(this);
        }
        
        public void OnStart()
        {
            _pauseToggleView.Show();
        }
        
        public void OnFinish()
        {
            _pauseToggleView.Hide();
        }

        private void OnToggleButtonClicked()
        {
            var gameState = _gameManager.GetGameState();
            
            if (gameState == EGameState.Playing)
            {
                _gameManager.PauseGame();
                _pauseToggleView.SetText(RESUME_TEXT);
            }
            else if (gameState == EGameState.Stopping)
            {
                _gameManager.ResumeGame();
                _pauseToggleView.SetText(PAUSE_TEXT);
            }
        }
    }
}