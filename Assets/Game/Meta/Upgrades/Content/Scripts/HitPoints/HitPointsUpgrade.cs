using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Game.Meta
{
    public sealed class HitPointsUpgrade : Upgrade, IGameInitElement
    {
        private readonly HitPointsUpgradeConfig config;

        [GameInject]
        private IHeroService heroService;

        private IComponent_SetupHitPoints heroComponent;

        public HitPointsUpgrade(HitPointsUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        public override string CurrentStats
        {
            get { return this.config.hitPointsTable.GetHitPoints(this.Level).ToString(); }
        }

        public override string NextImprovement
        {
            get { return this.config.hitPointsTable.HitPointsStep.ToString(); }
        }

        protected override void LevelUp(int level)
        {
            this.SetHitPoints(level);
        }

        private void SetHitPoints(int level)
        {
            var hitPoints = this.config.hitPointsTable.GetHitPoints(level);
            this.heroComponent.Setup(hitPoints, hitPoints);
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_SetupHitPoints>();
            this.SetHitPoints(this.Level);
        }
    }
}