using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Game.Meta
{
    public sealed class DamageUpgrade : Upgrade, IGameInitElement
    {
        private readonly DamageUpgradeConfig config;

        [GameInject]
        private IHeroService heroService;

        private IComponent_SetMeleeDamage heroComponent;
        
        public DamageUpgrade(DamageUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        public override string CurrentStats
        {
            get { return this.config.damageTable.GetDamage(this.Level).ToString(); }
        }

        public override string NextImprovement
        {
            get { return this.config.damageTable.DamageStep.ToString(); }
        }
        
        protected override void LevelUp(int level)
        {
            this.SetDamage(level);
        }

        private void SetDamage(int level)
        {
            var currentDamage = this.config.damageTable.GetDamage(level);
            this.heroComponent.SetDamage(currentDamage);
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_SetMeleeDamage>();
            this.SetDamage(this.Level);
        }
    }
}