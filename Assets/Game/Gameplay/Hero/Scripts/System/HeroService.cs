using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroService : IHeroService
    {
        [ShowInInspector, ReadOnly, Space]
        private IEntity currentHero;

        public void SetupHero(IEntity hero)
        {
            this.currentHero = hero;
        }

        public IEntity GetHero()
        {
            return this.currentHero;
        }
    }
}