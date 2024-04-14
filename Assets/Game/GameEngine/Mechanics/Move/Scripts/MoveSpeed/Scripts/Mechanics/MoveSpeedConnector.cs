using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class MoveSpeedConnector :
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private IVariable<float> baseSpeed;

        private IVariable<float> multiplier;

        private IVariable<float> fullSpeed;

        public void Construct(
            IVariable<float> baseSpeed,
            IVariable<float> multiplier,
            IVariable<float> fullSpeed
        )
        {
            this.baseSpeed = baseSpeed;
            this.multiplier = multiplier;
            this.fullSpeed = fullSpeed;
        }

        void IAwakeListener.Awake()
        {
            this.UpdateSpeed();
        }

        void IEnableListener.OnEnable()
        {
            this.baseSpeed.OnValueChanged += this.OnStateChanged;
            this.multiplier.OnValueChanged += this.OnStateChanged;
        }

        void IDisableListener.OnDisable()
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
            this.fullSpeed.Current = newSpeed;
        }
    }
}