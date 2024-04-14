using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Game.Meta
{
    public sealed class SpeedUpgrade : Upgrade, IGameInitElement
    {
        private readonly SpeedUpgradeConfig config;

        [GameInject]
        private IHeroService heroService;

        private IComponent_SetMoveSpeed heroComponent;

        public SpeedUpgrade(SpeedUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        public override string CurrentStats
        {
            get { return this.config.speedTable.GetSpeed(this.Level).ToString("F2"); }
        }

        public override string NextImprovement
        {
            get { return this.config.speedTable.SpeedStep.ToString("F2"); }
        }

        protected override void LevelUp(int level)
        {
            this.SetSpeed(level);
        }

        private void SetSpeed(int level)
        {
            var speed = this.config.speedTable.GetSpeed(level);
            this.heroComponent.SetSpeed(speed);
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_SetMoveSpeed>();
            this.SetSpeed(this.Level);
        }
    }
}