using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class SpeedBooster : Booster
    {
        [GameInject]
        private IHeroService heroService;

        private readonly IEffect speedEffect;

        public SpeedBooster(SpeedBoosterConfig config) : base(config)
        {
            this.speedEffect = new Effect(
                new FloatEffectParameter(EffectId.MOVE_SPEED, config.speedMultiplier)
            );
        }

        protected override void OnStart()
        {
            var hero = this.heroService.GetHero();
            hero.Get<IComponent_Effector>().Apply(this.speedEffect);
        }

        protected override void OnStop()
        {
            var hero = this.heroService.GetHero();
            hero.Get<IComponent_Effector>().Discard(this.speedEffect);
        }
    }
}