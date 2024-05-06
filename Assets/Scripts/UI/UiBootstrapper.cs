using Core;
using UI.Base;
using UI.GameFinishPanel;
using UI.GameStartPanel;
using UI.PauseTogglePanel;
using UnityEngine;
using VContainer;

namespace UI
{
    public class UiBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameFinishView _gameFinishView;
        [SerializeField] private GameStartView _gameStartView;
        [SerializeField] private PauseToggleView _pauseTogglePanel;

        private GameFinishViewController _gameFinishViewController;
        private GameStartViewController _gameStartViewController;
        private PauseToggleViewController _pauseToggleViewController;

        private GameManager _gameManager;

        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        private void Awake()
        {
            _gameFinishViewController = new GameFinishViewController(_gameFinishView, _gameManager);
            _gameStartViewController = new GameStartViewController(_gameStartView, _gameManager);
            _pauseToggleViewController = new PauseToggleViewController(_pauseTogglePanel, _gameManager);
        }
    }
}