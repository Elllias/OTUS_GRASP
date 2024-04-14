using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameNodes
{
    public interface IMoveInput
    {
        event Action<Vector2> OnMoved;
    }

    [Serializable]
    public sealed class MoveInput : IMoveInput, IGameUpdater
    {
        public event Action<Vector2> OnMoved;
        
        private InputSystem inputSystem;

        [ShowInInspector, ReadOnly]
        private bool enabled;

        [Space]
        [SerializeField]
        private KeyCode upCode;

        [SerializeField]
        private KeyCode downCode;

        [SerializeField]
        private KeyCode leftCode;

        [SerializeField]
        private KeyCode rightCode;

        [GameInit]
        public void Init(InputSystem inputSystem)
        {
            this.inputSystem = inputSystem;
        }
        
        [GameStart]
        public void Enable()
        {
            this.enabled = true;
        }

        [GameFinish]
        public void Disable()
        {
            this.enabled = false;
        }

        void IGameUpdater.Update(float deltaTime)
        {
            if (this.enabled)
            {
                this.HandleInput();
            }
        }

        private void HandleInput()
        {
            if (this.inputSystem.GetKey(this.upCode))
            {
                this.OnMoved?.Invoke(Vector2.up);
            }
            else if (this.inputSystem.GetKey(this.downCode))
            {
                this.OnMoved?.Invoke(Vector2.down);
            }

            if (this.inputSystem.GetKey(this.leftCode))
            {
                this.OnMoved?.Invoke(Vector2.left);
            }
            else if (this.inputSystem.GetKey(this.rightCode))
            {
                this.OnMoved?.Invoke(Vector2.right);
            }
        }
    }
}