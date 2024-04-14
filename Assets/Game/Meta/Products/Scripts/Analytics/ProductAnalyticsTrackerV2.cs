using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductAnalyticsTrackerV2 : MonoBehaviour, 
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private ProductBuyer buyManager;

        [GameInject]
        private MoneyStorage moneyStorage;

        private int previousMoney;

        void IGameReadyElement.ReadyGame()
        {
            this.buyManager.OnBuyStarted += this.OnStartBuy;
            this.buyManager.OnBuyCompleted += this.OnFinishBuy;
        }

        void IGameFinishElement.FinishGame()
        {
            this.buyManager.OnBuyStarted -= this.OnStartBuy;
            this.buyManager.OnBuyCompleted -= this.OnFinishBuy;
        }

        private void OnStartBuy(Product product)
        {
            this.previousMoney = this.moneyStorage.Money;
        }

        private void OnFinishBuy(Product product)
        {
            ProductAnalytics.LogProductBought(product, this.previousMoney, this.moneyStorage.Money);
        }
    }
}