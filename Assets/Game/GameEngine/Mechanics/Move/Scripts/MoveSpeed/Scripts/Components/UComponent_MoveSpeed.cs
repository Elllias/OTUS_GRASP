using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Component «Move Speed»")]
    public sealed class UComponent_MoveSpeed : MonoBehaviour,
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

        [SerializeField]
        private MonoFloatVariable moveSpeed;

        public void SetSpeed(float speed)
        {
            this.moveSpeed.SetValue(speed);
        }
    }
}