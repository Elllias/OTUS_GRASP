using Game.GameEngine.InventorySystem;

namespace Game.Meta
{
    public sealed class BoosterInventoryItemConsumeHandler : IInventoryItemConsumeHandler
    {
        private readonly BoostersManager boostersManager;

        public BoosterInventoryItemConsumeHandler(BoostersManager boostersManager)
        {
            this.boostersManager = boostersManager;
        }

        void IInventoryItemConsumeHandler.OnConsume(InventoryItem item)
        {
            if (item.TryGetComponent(out IComponent_BoosterInfo boosterComponent))
            {
                BoosterConfig boosterConfig = boosterComponent.BoosterInfo;
                this.boostersManager.LaunchBooster(boosterConfig);
            }
        }
    }
}