using System;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Damage/Component «Melee Damage»")]
    public sealed class UComponent_MeleeDamage : MonoBehaviour,
        IComponent_GetMeleeDamage,
        IComponent_SetMeleeDamage,
        IComponent_OnMeleeDamageChanged
    {
        public event Action<int> OnDamageChanged
        {
            add { this.damage.OnValueChanged += value; }
            remove { this.damage.OnValueChanged -= value; }
        }

        public int Damage
        {
            get { return this.damage.Current; }
        }

        [SerializeField]
        private MonoIntVariable damage;

        public void SetDamage(int damage)
        {
            this.damage.SetValue(damage);
        }
    }
}