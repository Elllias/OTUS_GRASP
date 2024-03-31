using System;
using Interface;
using UnityEngine;
using VContainer.Unity;

namespace LevelUtils
{
    public class LevelBackgroundController : MonoBehaviour, IStartListener, IPauseListener, IResumeListener, IFinishListener, ITickable
    {
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _endPositionY;
        [SerializeField] private float _movingSpeedY;
        
        private Vector3 _movingVector;
        private Vector3 _startingVector;

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
            if (transform.position.y <= _endPositionY)
            {
                transform.position = _startingVector;
            }

            transform.position -= _movingVector;
        }
    }
}