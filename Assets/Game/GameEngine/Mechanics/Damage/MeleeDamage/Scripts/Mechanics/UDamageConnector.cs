using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Damage/Damage Connector")]
    public sealed class UDamageConnector : MonoBehaviour
    {
        [FormerlySerializedAs("baseDamage")]
        [SerializeField]
        public MonoIntVariable baseValue;

        [SerializeField]
        public MonoFloatVariable multiplier;

        [FormerlySerializedAs("fullDamage")]
        [SerializeField]
        public MonoIntVariable fullValue;

        private void Awake()
        {
            this.UpdateDamage();
        }

        private void OnEnable()
        {
            this.baseValue.OnValueChanged += this.OnValueChanged;
            this.multiplier.OnValueChanged += this.OnMultiplierChanged;
        }

        private void OnDisable()
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
            this.fullValue.SetValue(newValue);
        }

        private void UpdateDamage()
        {
            var newDamage = this.EvaluateFullValue();
            this.fullValue.SetValue(newDamage);
        }

        private int EvaluateFullValue()
        {
            var damage = this.baseValue.Current * this.multiplier.Current;
            return Mathf.RoundToInt(damage);
        }
    }
}