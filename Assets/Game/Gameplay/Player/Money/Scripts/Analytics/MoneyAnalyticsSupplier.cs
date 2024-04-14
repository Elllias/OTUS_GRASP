using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class MoneyAnalyticsSupplier : MonoBehaviour,
        IGameConstructElement,
        IGameReadyElement,
        IGameFinishElement
    {
        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        public int PreviousMoney { get; private set; }

        [PropertyOrder(-9)]
        [ReadOnly]
        [ShowInInspector]
        public int CurrentMoney { get; private set; }

        [Space]
        [SerializeField]
        private MoneyStorage storage;

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.PreviousMoney = this.storage.Money;
            this.CurrentMoney = this.storage.Money;
        }

        void IGameReadyElement.ReadyGame()
        {
            this.storage.OnMoneyChanged += this.OnMoneyChanged;
        }

        void IGameFinishElement.FinishGame()
        {
            this.storage.OnMoneyChanged -= this.OnMoneyChanged;
        }

        private void OnMoneyChanged(int newValue)
        {
            this.PreviousMoney = this.CurrentMoney;
            this.CurrentMoney = newValue;
        }
    }
}