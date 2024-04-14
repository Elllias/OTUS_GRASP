using Game.GameEngine.InventorySystem;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;

namespace Game.Meta
{
    public sealed class HealingInventoryItemConsumeHandler : IInventoryItemConsumeHandler
    {
        private readonly HeroService heroService;
        
        public HealingInventoryItemConsumeHandler(HeroService heroService)
        {
            this.heroService = heroService;
        }

        void IInventoryItemConsumeHandler.OnConsume(InventoryItem item)
        {
            if (!item.TryGetComponent(out IComponent_GetHealingPoints healingComponent))
            {
                return;
            }

            if (!this.heroService.GetHero().TryGet(out IComponent_AddHitPoints hitPointsComponent))
            {
                return;
            }

            var healingPoints = healingComponent.HealingPoints;
            hitPointsComponent.AddHitPoints(healingPoints);
        }
    }
}