using System;
using Sirenix.OdinInspector;

namespace Lessons.Meta.Quests1
{
    public abstract class Quest
    {
        public event Action<Quest> OnStarted;
        public event Action<Quest, float> OnProgressChanged;
        public event Action<Quest> OnCompleted;

        [ReadOnly]
        [ShowInInspector]
        public string Id
        {
            get { return this.config.id; }
        }

        [ReadOnly]
        [ShowInInspector]
        public bool IsCompleted { get; private set; }

        [ReadOnly]
        [ShowInInspector]
        public abstract float Progress { get; } //0..1

        [ReadOnly]
        [ShowInInspector]
        public int MoneyReward
        {
            get { return this.config.moneyReward; }
        }

        private readonly QuestConfig config;

        public Quest(QuestConfig config)
        {
            this.config = config;
        }

        public void Start()
        {
            this.IsCompleted = false;
            this.OnStarted?.Invoke(this);

            if (this.Progress >= 1.0f)
            {
                //Complete quest
                this.Complete();
            }
            else
            {
                //Process:
                this.OnStart();
            }
        }

        private void Complete()
        {
            if (this.IsCompleted)
            {
                return;
            }

            this.IsCompleted = true;
            this.OnStop();
            this.OnCompleted?.Invoke(this);
        }

        protected abstract void OnStart();
        protected abstract void OnStop();

        //Derived classes
        protected void UpdateProgress()
        {
            if (this.IsCompleted)
            {
                return;
            }
            
            this.OnProgressChanged?.Invoke(this, this.Progress);
            if (this.Progress >= 1)
            {
                this.Complete();
            }
        }
    }
}