using System;
using Interface;
using UnityEngine;

namespace LevelUtils
{
    public sealed class LevelBackgroundController : MonoBehaviour, IStartListener, IUpdateListener
    {
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _endPositionY;
        [SerializeField] private float _movingSpeedY;
        
        private Vector3 _movingVector;
        private Vector3 _startingVector;

        public void OnStart()
        {
            _movingVector = new Vector3(0, _movingSpeedY * Time.fixedDeltaTime, 0);
            _startingVector = new Vector3(0, _startPositionY, 0);
        }

        public void OnUpdate()
        {
            if (transform.position.y <= _endPositionY)
            {
                transform.position = _startingVector;
            }

            transform.position -= _movingVector;
        }
    }
}