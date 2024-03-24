using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameStartPanel
{
    public class GameStartView : MonoBehaviour
    {
        public event Action StartButtonClicked;
        
        [SerializeField] private Button _startButton;
        [SerializeField] private TMP_Text _timerText;

        private void Awake()
        {
            _startButton.onClick.AddListener(OnClickStartButton);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetText(string newText)
        {
            _timerText.text = newText;
        }

        public void TurnTimerText(bool value)
        {
            _timerText.gameObject.SetActive(value);
        }

        public void TurnStartButton(bool value)
        {
            _startButton.gameObject.SetActive(value);
        }
        
        private void OnClickStartButton()
        {
            StartButtonClicked?.Invoke();
        }
    }
}