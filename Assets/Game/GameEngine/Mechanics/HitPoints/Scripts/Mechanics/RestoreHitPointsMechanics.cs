using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class RestoreHitPointsMechanics : IEnableListener, IDisableListener
    {
        private readonly Countdown delay = new();

        private readonly Period period = new();

        private IHitPoints hitPoints;

        private IEmitter<TakeDamageArgs> takeDamageEmitter;

        private int restoreAtTime;

        public void SetRestoreAtTime(int value)
        {
            this.restoreAtTime = value;
        }

        public void SetDelay(float delay)
        {
            this.delay.Duration = delay;
        }

        public void SetPeriod(float period)
        {
            this.period.Duration = period;
        }

        public void Construct(IHitPoints hitPoints, IEmitter<TakeDamageArgs> takeDamageEmitter)
        {
            this.hitPoints = hitPoints;
            this.takeDamageEmitter = takeDamageEmitter;
        }

        void IEnableListener.OnEnable()
        {
            this.takeDamageEmitter.OnEvent += this.OnDamageTaken;
            this.delay.OnEnded += this.OnDelayEnded;
            this.period.OnPeriodEvent += this.OnRestoreHitPoints;
        }

        void IDisableListener.OnDisable()
        {
            this.takeDamageEmitter.OnEvent -= this.OnDamageTaken;
            this.delay.OnEnded -= this.OnDelayEnded;
            this.period.OnPeriodEvent -= this.OnRestoreHitPoints;
        }

        private void OnDamageTaken(TakeDamageArgs damageArgs)
        {
            if (this.hitPoints.Current <= 0)
            {
                return;
            }

            //Сброс задержки:
            this.delay.ResetTime();
            if (!this.delay.IsPlaying)
            {
                this.delay.Play();
            }

            //Сброс периода:
            this.period.Stop();
        }

        private void OnDelayEnded()
        {
            this.period.Play();
        }

        private void OnRestoreHitPoints()
        {
            this.hitPoints.Current += this.restoreAtTime;
            if (this.hitPoints.Current >= this.hitPoints.Max)
            {
                this.period.Stop();
            }
        }
    }
}