using System;
using UnityEngine;

namespace LevelUtils
{
    public sealed class LevelBackgroundController : MonoBehaviour
    {
        [SerializeField] private float _startPositionY;
        [SerializeField] private float _endPositionY;
        [SerializeField] private float _movingSpeedY;
        
        private Vector3 _movingVector;
        private Vector3 _startingVector;

        private void Awake()
        {
            _movingVector = new Vector3(0, _movingSpeedY * Time.fixedDeltaTime, 0);
            _startingVector = new Vector3(0, _startPositionY, 0);
        }

        private void FixedUpdate()
        {
            if (transform.position.y <= _endPositionY)
            {
                transform.position = _startingVector;
            }

            transform.position -= _movingVector;
        }
    }
}