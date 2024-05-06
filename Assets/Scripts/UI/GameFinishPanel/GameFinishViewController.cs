using Core;
using Interface;
using UI.Base;
using UnityEngine;
using VContainer;

namespace UI.GameFinishPanel
{
    public class GameFinishViewController : IFinishListener
    {
        private const string FINISH_MESSAGE = "Game Over!";

        private readonly GameFinishView _gameFinishView;
        private readonly GameManager _gameManager;
        
        public GameFinishViewController(GameFinishView gameFinishView, GameManager gameManager)
        {
            _gameManager = gameManager;
            _gameFinishView = gameFinishView;
            
            _gameManager.AddFinishListener(this);
            _gameFinishView.Hide();
        }

        ~GameFinishViewController()
        {
            _gameManager.RemoveFinishListener(this);
        }
    
        public void OnFinish()
        {
            _gameFinishView.SetText(FINISH_MESSAGE);
            _gameFinishView.Show();
        }
    }
}