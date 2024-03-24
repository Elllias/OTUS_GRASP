using System;
using Core;
using Enum;
using Interface;
using UnityEngine;

namespace UI.PauseTogglePanel
{
    public class PauseToggleViewController : MonoBehaviour, IStartListener, IFinishListener
    {
        private const string RESUME_TEXT = "Resume";
        private const string PAUSE_TEXT = "Pause";
        
        [SerializeField] private PauseToggleView _pauseToggleView;

        private void Awake()
        {
            _pauseToggleView.ToggleButtonClicked += OnToggleButtonClicked;
            
            _pauseToggleView.Hide();
            _pauseToggleView.SetText(PAUSE_TEXT);
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
            var gameState = GameManager.Instance.GetGameState();
            
            if (gameState == EGameState.Playing)
            {
                GameManager.Instance.PauseGame();
                _pauseToggleView.SetText(RESUME_TEXT);
            }
            else if (gameState == EGameState.Stopping)
            {
                GameManager.Instance.ResumeGame();
                _pauseToggleView.SetText(PAUSE_TEXT);
            }
        }
    }
}