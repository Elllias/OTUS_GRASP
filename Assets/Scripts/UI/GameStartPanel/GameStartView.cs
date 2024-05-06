using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameStartPanel
{
    public class GameStartView : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private TMP_Text _timerText;

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

        public Button GetButton()
        {
            return _startButton;
        }
    }
}