using Game.GameEngine;
using Game.GameEngine.InventorySystem;
using Game.GameEngine.Products;
using GameSystem;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class BoostersModule : GameModule
    {
        [GameService, GameElement]
        [ShowInInspector]
        private BoostersManager manager = new();

        [GameElement]
        private readonly BoosterAnalyticsTracker analyticsTracker = new();

        [UsedImplicitly]
        private readonly BoosterFactory factory = new();

        public override void ConstructGame(GameContext context)
        {
            base.ConstructGame(context);
            this.ConstructControllers(context);
        }

        private void ConstructControllers(GameContext context)
        {
            var consumeManager = context.GetService<InventoryItemConsumer>();
            consumeManager.AddHandler(new BoosterInventoryItemConsumeHandler(this.manager));

            var productManager = context.GetService<ProductBuyer>();
            productManager.AddCompletor(new BoosterBuyCompletor(this.manager));

            var timeShiftEmitter = context.GetService<TimeShiftEmitter>();
            timeShiftEmitter.AddHandler(new BoostersTimeSynchronizer(this.manager));
        }
    }
}