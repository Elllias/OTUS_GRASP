using Game.Gameplay.Player;
using GameSystem;
using Game.GameEngine;
using Game.Gameplay;

namespace Game.Meta
{
    public sealed class IncomeBooster : Booster
    {
        [GameInject]
        private VendorInteractor vendorInteractor;

        private readonly IncomeBoosterConfig config;

        public IncomeBooster(IncomeBoosterConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnStart()
        {
            this.vendorInteractor.IncomeMultiplier *= this.config.incomeCoefficient;
        }

        protected override void OnStop()
        {
            this.vendorInteractor.IncomeMultiplier /= this.config.incomeCoefficient; 
        }
    }
}