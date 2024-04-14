using System;
using Elementary;
using Sirenix.OdinInspector;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public abstract class Booster
    {
        public event Action<Booster> OnStarted;

        public event Action<Booster, float> OnTimeChanged;

        public event Action<Booster> OnCompleted;

        [ShowInInspector, ReadOnly]
        public string Id
        {
            get { return this.config.id; }
        }

        [ShowInInspector, ReadOnly]
        public bool IsActive
        {
            get { return this.countdown.IsPlaying; }
        }

        [ShowInInspector, ReadOnly]
        public float RemainingSeconds
        {
            get { return this.countdown.RemainingTime; }
            set { this.countdown.RemainingTime = value; }
        }

        [ShowInInspector, ReadOnly]
        public float DurationSeconds
        {
            get { return this.config.durationSeconds; }
        }

        [ShowInInspector, ReadOnly]
        public int MoneyPrice
        {
            get { return this.config.moneyPrice; }
        }

        private readonly BoosterConfig config;

        private readonly Countdown countdown;

        public Booster(BoosterConfig config)
        {
            this.config = config;
            this.countdown = new Countdown(config.durationSeconds);
        }

        public void Start()
        {
            if (this.IsActive)
            {
                throw new Exception("Already playing!");
            }

            this.countdown.OnTimeChanged += this.OnChangeTime;
            this.countdown.OnEnded += this.OnEndTime;

            this.OnStart();
            this.OnStarted?.Invoke(this);

            this.countdown.ResetTime();
            this.countdown.Play();
        }

        protected abstract void OnStart();

        protected abstract void OnStop();

        private void OnChangeTime()
        {
            this.OnTimeChanged?.Invoke(this, this.RemainingSeconds);
        }

        private void OnEndTime()
        {
            this.countdown.OnEnded -= this.OnEndTime;
            this.countdown.OnTimeChanged -= this.OnChangeTime;

            this.OnStop();
            this.OnCompleted?.Invoke(this);
        }
    }
}