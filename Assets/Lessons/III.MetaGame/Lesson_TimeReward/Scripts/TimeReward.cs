using System;
using Elementary;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame
{
    public sealed class TimeReward : IGameStartElement, IRealtimeTimer
    {
        public event Action<IRealtimeTimer> OnStarted;
        
        [ShowInInspector, ReadOnly]
        public string Id => nameof(TimeReward);

        [ShowInInspector, ReadOnly]
        private readonly Countdown timer = new();
        
        private MoneyStorageDecorator moneyStorage;
        private TimeRewardConfig config;
        
        public void Construct(MoneyStorageDecorator moneyStorage, TimeRewardConfig config)
        {
            this.moneyStorage = moneyStorage;
            this.config = config;

            this.timer.Duration = config.duration;
            this.timer.RemainingTime = config.duration;
        }
        
        [Button]
        public bool CanReceiveReward()
        {
            return this.timer.Progress >= 1;
        }

        [Button]
        public void ReceiveReward()
        {
            if (!this.CanReceiveReward())
            {
                Debug.LogError("Can't receive reward!");
                return;
            }

            this.moneyStorage.EarnMoneySimple(this.config.moneyReward);
            
            this.timer.ResetTime();
            this.timer.Play();
            this.OnStarted?.Invoke(this);
        }
        
        void IGameStartElement.StartGame()
        {
            if (this.timer.Progress <= 0)
            {
                this.OnStarted?.Invoke(this);
            }

            this.timer.Play();
        }

        void IRealtimeTimer.Synchronize(float offlineSeconds)
        {
            this.timer.RemainingTime -= offlineSeconds;
        }
    }
}