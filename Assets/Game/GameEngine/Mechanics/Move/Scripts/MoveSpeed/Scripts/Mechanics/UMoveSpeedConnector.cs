using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move Speed Connector")]
    public sealed class UMoveSpeedConnector : MonoBehaviour
    {
        [SerializeField]
        public MonoFloatVariable baseSpeed;

        [SerializeField]
        public MonoFloatVariable multiplier;

        [Space]
        [SerializeField]
        public MonoFloatVariable fullSpeed;

        private void Awake()
        {
            this.UpdateSpeed();
        }

        private void OnEnable()
        {
            this.baseSpeed.OnValueChanged += this.OnStateChanged;
            this.multiplier.OnValueChanged += this.OnStateChanged;
        }

        private void OnDisable()
        {
            this.baseSpeed.OnValueChanged -= this.OnStateChanged;
            this.multiplier.OnValueChanged -= this.OnStateChanged;
        }

        private void OnStateChanged(float _)
        {
           this.UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            var newSpeed = this.baseSpeed.Current * this.multiplier.Current;
            this.fullSpeed.SetValue(newSpeed);
        }
    }
}