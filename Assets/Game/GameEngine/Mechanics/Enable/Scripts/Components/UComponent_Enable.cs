using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Enable/Component «Enable»")]
    public sealed class UComponent_Enable : MonoBehaviour, IComponent_Enable
    {
        public event Action<bool> OnEnabled
        {
            add { this.isEnable.OnValueChanged += value; }
            remove { this.isEnable.OnValueChanged -= value; }
        }

        public bool IsEnable
        {
            get { return this.isEnable.Current; }
        }

        public void SetEnable(bool isEnable)
        {
            this.isEnable.SetValue(isEnable);
        }

        [SerializeField]
        private MonoBoolVariable isEnable;
    }
}