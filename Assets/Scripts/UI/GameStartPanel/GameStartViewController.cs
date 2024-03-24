using System.Collections;
using Core;
using Interface;
using UnityEngine;

namespace UI.GameStartPanel
{
    public class GameStartViewController : MonoBehaviour
    {
        private const int TIMER_DURATION = 3;

        [SerializeField] private GameStartView _gameStartView;

        private void Awake()
        {
            _gameStartView.StartButtonClicked += OnStartButtonClicked;
            
            _gameStartView.Show();
        }

        private void OnStartButtonClicked()
        {
            _gameStartView.TurnStartButton(false);

            StartCoroutine(StartGameStartTimer());
        }

        private IEnumerator StartGameStartTimer()
        {
            var timer = TIMER_DURATION;

            _gameStartView.TurnTimerText(true);

            while (timer > 0)
            {
                _gameStartView.SetText($"Игра начнется через {timer}...");

                yield return new WaitForSeconds(1);

                timer -= 1;
            }

            _gameStartView.Hide();
            GameManager.Instance.StartGame();
        }
    }
}