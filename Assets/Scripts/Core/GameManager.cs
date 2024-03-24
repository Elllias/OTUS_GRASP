using System;
using Character;
using UnityEngine;

namespace Core
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private InputHandler _inputHandler;

        private void OnEnable()
        {
            _player.Killed += FinishGame;
        }

        private void OnDisable()
        {
            _player.Killed -= FinishGame;
        }

        private void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
            
            _inputHandler.enabled = false;
        }
    }
}