using Core;
using Interface;
using UnityEngine;
using VContainer.Unity;

namespace LevelUtils
{
    public class LevelBackgroundController : IStartListener, IPauseListener, IResumeListener, IFinishListener
    {
        private readonly Transform _backgroundTransform;
        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private readonly GameManager _gameManager;

        private Vector3 _movingVector;
        private Vector3 _startingVector;

        public LevelBackgroundController(
            Transform backgroundTransform,
            float startPositionY,
            float endPositionY,
            float movingSpeedY,
            GameManager gameManager)
        {
            _backgroundTransform = backgroundTransform;
            _startPositionY = startPositionY;
            _endPositionY = endPositionY;
            _movingSpeedY = movingSpeedY;
            _gameManager = gameManager;
            
            _gameManager.AddStartListener(this);
            _gameManager.AddPauseListener(this);
            _gameManager.AddFinishListener(this);
            _gameManager.AddResumeListener(this);
        }

        ~LevelBackgroundController()
        {
            _gameManager.RemoveStartListener(this);
            _gameManager.RemovePauseListener(this);
            _gameManager.RemoveFinishListener(this);
            _gameManager.RemoveResumeListener(this);
        }
        
        public void OnStart()
        {
            OnResume();
        }
        
        public void OnFinish()
        {
            OnPause();
        }
        
        public void OnPause()
        {
            _movingVector = Vector3.zero;
            _startingVector = Vector3.zero;
        }

        public void OnResume()
        {
            _movingVector = new Vector3(0, _movingSpeedY * Time.fixedDeltaTime, 0);
            _startingVector = new Vector3(0, _startPositionY, 0);
        }
        
        public void Tick()
        {
            if (_backgroundTransform.position.y <= _endPositionY)
            {
                _backgroundTransform.position = _startingVector;
            }

            _backgroundTransform.position -= _movingVector;
        }
    }
}