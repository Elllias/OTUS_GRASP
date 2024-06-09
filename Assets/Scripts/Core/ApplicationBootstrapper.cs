using System;
using Atomic.Objects;
using UnityEngine;

namespace Core
{
    public class ApplicationBootstrapper : MonoBehaviour
    {
        [SerializeField] private AtomicEntity _character;
        
        private InputHandler _inputHandler;
        
        public void Awake()
        {
            _inputHandler = new InputHandler(_character);
        }

        public void Update()
        {
            _inputHandler.Update();
        }
    }
}