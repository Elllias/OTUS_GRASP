using Game.App;
using Game.GameEngine.Products;
using Game.Gameplay.Player;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductAnalytics : MonoBehaviour
    {
        public static void LogProductBought(
            Product product,
            int previousMoney,
            int currentMoney
        )
        {
            const string eventName = "product_bought";
            AnalyticsManager.LogEvent(eventName,
                ProductId(product),
                MoneyAnalytics.PreviousMoney(previousMoney),
                MoneyAnalytics.CurrentMoney(currentMoney)
            );
        }

        public static AnalyticsParameter ProductId(Product product)
        {
            const string name = "product_id";
            return new AnalyticsParameter(name, product.Id);
        }
    }
}