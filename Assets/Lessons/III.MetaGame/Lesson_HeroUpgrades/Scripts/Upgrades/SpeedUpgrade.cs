using Entities;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using Game.Meta;
using GameSystem;

namespace Lessons.MetaGame.Upgrades
{
    public sealed class SpeedUpgrade : Upgrade, IGameInitElement
    {
        private readonly SpeedUpgradeTable speedTable;
        private IEntity hero;
    
        public SpeedUpgrade(SpeedUpgradeConfig config) : base(config)
        {
            this.speedTable = config.speedTable;
        }

        [GameInject]
        public void Construct(IHeroService heroService)
        {
            this.hero = heroService.GetHero();
        }

        void IGameInitElement.InitGame()
        {
            var speed = this.speedTable.GetSpeed(this.Level);
            this.hero.Get<IComponent_SetMoveSpeed>().SetSpeed(speed);
        }

        public override void OnLevelUp(int levelUp)
        {
            float speed = this.speedTable.GetSpeed(levelUp);
            this.hero.Get<IComponent_SetMoveSpeed>().SetSpeed(speed);
        }
    }
}