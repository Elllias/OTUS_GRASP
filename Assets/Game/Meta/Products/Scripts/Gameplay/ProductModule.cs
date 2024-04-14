using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductModule : GameModule
    {
        [GameService]
        [ShowInInspector]
        private readonly ProductBuyer productBuyer = new();
        
        [GameElement]
        private readonly ProductAnalyticsTrackerV1 analyticsTracker = new();

        public override void ConstructGame(GameContext context)
        {
            base.ConstructGame(context);
            this.ConstructProductBuyer(context);
        }

        private void ConstructProductBuyer(GameContext context)
        {
            var moneyBank = context.GetService<MoneyStorage>();
            this.productBuyer.AddCondition(new ProductBuyCondition_CanSpendMoney(moneyBank));
            this.productBuyer.AddProcessor(new ProductBuyProcessor_SpendMoney(moneyBank));
            
            var resourceStorage = context.GetService<ResourceStorage>();
            this.productBuyer.AddCondition(new ProductBuyCondition_CanSpendResources(resourceStorage));
            this.productBuyer.AddProcessor(new ProductBuyProcessor_SpendResources(resourceStorage));
        }
    }
}