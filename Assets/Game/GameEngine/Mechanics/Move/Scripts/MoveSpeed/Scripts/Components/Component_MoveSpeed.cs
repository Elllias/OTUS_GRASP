using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_MoveSpeed : 
        IComponent_GetMoveSpeed,
        IComponent_SetMoveSpeed,
        IComponent_OnMoveSpeedChanged
    {
        public event Action<float> OnSpeedChanged
        {
            add { this.moveSpeed.OnValueChanged += value; }
            remove { this.moveSpeed.OnValueChanged -= value; }
        }

        public float Speed
        {
            get { return this.moveSpeed.Current; }
        }

        private readonly IVariable<float> moveSpeed;

        public Component_MoveSpeed(IVariable<float> moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public void SetSpeed(float speed)
        {
            this.moveSpeed.Current = speed;
        }
    }
}