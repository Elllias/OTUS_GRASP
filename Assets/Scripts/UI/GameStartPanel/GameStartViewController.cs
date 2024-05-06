using System.Collections;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace UI.GameStartPanel
{
    public class GameStartViewController
    {
        private const int TIMER_DURATION = 3;

        private readonly GameStartView _gameStartView;
        private readonly GameManager _gameManager;

        public GameStartViewController(GameStartView gameStartView, GameManager gameManager)
        {
            _gameStartView = gameStartView;
            _gameManager = gameManager;
            
            _gameStartView.GetButton().onClick.AddListener(OnStartButtonClicked);
            _gameStartView.Show();
        }

        private void OnStartButtonClicked()
        {
            _gameStartView.TurnStartButton(false);
            _gameStartView.StartCoroutine(StartGameStartTimer());
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
            _gameManager.StartGame();
        }
    }
}