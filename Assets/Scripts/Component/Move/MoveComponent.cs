using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector2 = UnityEngine.Vector2;

namespace Component.Move
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _speed = 0.1f;

        private MoveController _controller;

        public void Construct()
        {
            _controller = new MoveController(this, _rigidbody, _speed);
        }

        public MoveController GetController()
        {
            return _controller;
        }
    }
}