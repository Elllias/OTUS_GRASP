using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class MoneyPanelAdapter : MonoBehaviour,
        IGameConstructElement,
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        [SerializeField]
        private bool listenIncome = false;

        [SerializeField]
        private bool listenSpend = true;

        [SerializeField]
        private MoneyPanel panel;

        private MoneyStorage storage;

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.storage = context.GetService<MoneyStorage>();
        }

        void IGameInitElement.InitGame()
        {
            this.panel.SetupMoney(this.storage.Money);
        }

        void IGameReadyElement.ReadyGame()
        {
            if (this.listenIncome)
            {
                this.storage.OnMoneyEarned += this.OnMoneyEarned;
            }

            if (this.listenSpend)
            {
                this.storage.OnMoneySpent += this.OnMoneySpent;
            }
        }

        void IGameFinishElement.FinishGame()
        {
            if (this.listenIncome)
            {
                this.storage.OnMoneyEarned -= this.OnMoneyEarned;
            }

            if (this.listenSpend)
            {
                this.storage.OnMoneySpent -= this.OnMoneySpent;
            }
        }

        private void OnMoneySpent(int range)
        {
            this.panel.DecrementMoney(range);
        }

        private void OnMoneyEarned(int range)
        {
            this.panel.IncrementMoney(range);
        }

#if UNITY_EDITOR

        [Button]
        private void Editor_UpdateMoney()
        {
            this.panel.SetupMoney(this.storage.Money);
        }
#endif
    }
}