using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;

namespace Game.Meta
{
    public sealed class ProductAnalyticsTrackerV1 :
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private ProductBuyer buyManager;

        [GameInject]
        private MoneyAnalyticsSupplier moneySupplier;

        void IGameReadyElement.ReadyGame()
        {
            this.buyManager.OnBuyCompleted += this.OnBuyProduct;
        }

        void IGameFinishElement.FinishGame()
        {
            this.buyManager.OnBuyCompleted -= this.OnBuyProduct;
        }

        private void OnBuyProduct(Product product)
        {
            ProductAnalytics.LogProductBought(
                product,
                previousMoney: this.moneySupplier.PreviousMoney,
                currentMoney: this.moneySupplier.CurrentMoney
            );
        }
    }
}