using Elementary;
using Declarative;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class DamageConnector : IAwakeListener, IEnableListener, IDisableListener
    {
        public IVariable<int> baseValue;

        public IVariable<float> multiplier;

        public IVariable<int> fullValue;

        public void Construct(
            IVariable<int> baseValue,
            IVariable<float> multiplier,
            IVariable<int> fullValue
        )
        {
            this.baseValue = baseValue;
            this.multiplier = multiplier;
            this.fullValue = fullValue;
        }

        void IAwakeListener.Awake()
        {
            this.UpdateDamage();
        }

        void IEnableListener.OnEnable()
        {
            this.baseValue.OnValueChanged += this.OnValueChanged;
            this.multiplier.OnValueChanged += this.OnMultiplierChanged;
        }

        void IDisableListener.OnDisable()
        {
            this.baseValue.OnValueChanged -= this.OnValueChanged;
            this.multiplier.OnValueChanged -= this.OnMultiplierChanged;
        }

        private void OnMultiplierChanged(float _)
        {
            this.UpdateDamage();
        }

        private void OnValueChanged(int _)
        {
            var newValue = this.EvaluateFullValue();
            this.fullValue.Current = newValue;
        }

        private void UpdateDamage()
        {
            var newDamage = this.EvaluateFullValue();
            this.fullValue.Current = newDamage;
        }

        private int EvaluateFullValue()
        {
            var damage = this.baseValue.Current * this.multiplier.Current;
            return Mathf.RoundToInt(damage);
        }
    }
}