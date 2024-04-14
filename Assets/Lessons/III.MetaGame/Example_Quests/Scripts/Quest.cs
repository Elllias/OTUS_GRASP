using System;
using Sirenix.OdinInspector;

namespace Lessons.Meta
{
    public abstract class Quest
    {
        public event Action<Quest> OnStarted;

        public abstract event Action<Quest, float> OnProgressChanged;

        public event Action<Quest> OnStopped;

        public event Action<Quest> OnCompleted;

        [ReadOnly]
        [ShowInInspector]
        public string Id
        {
            get { return this.config.id; }
        }

        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        public QuestState State { get; private set; }

        [PropertySpace]
        [ReadOnly]
        [ProgressBar(0, 1)]
        [ShowInInspector]
        public abstract float Progress { get; }

        [ReadOnly]
        [ShowInInspector]
        public abstract string TextProgress { get; }

        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        public int MoneyReward
        {
            get { return this.config.moneyReward; }
        }

        private readonly QuestConfig config;

        protected Quest(QuestConfig config)
        {
            this.config = config;
        }

        public void Start()
        {
            if (this.State > QuestState.NOT_STARTED)
            {
                throw new Exception("Mission is already started!");
            }

            this.State = QuestState.PROCESSING;
            this.OnStarted?.Invoke(this);

            if (this.Progress >= 1.0f)
            {
                this.Complete();
                return;
            }

            this.OnStart();
        }

        public void Stop()
        {
            if (this.State != QuestState.PROCESSING)
            {
                return;
            }

            this.State = QuestState.NOT_STARTED;
            this.OnEnd();
            this.OnStopped?.Invoke(this);
        }

        protected abstract void OnStart();

        protected abstract void OnEnd();

        protected void TryComplete()
        {
            if (this.Progress >= 1.0f)
            {
                this.Complete();
            }
        }

        private void Complete()
        {
            if (this.State == QuestState.NOT_STARTED)
            {
                throw new Exception("Mission is not started!");
            }

            if (this.State == QuestState.COMPLETED)
            {
                throw new Exception("Mission is already completed!");
            }

            this.State = QuestState.COMPLETED;
            this.OnEnd();
            this.OnCompleted?.Invoke(this);
        }
    }
}