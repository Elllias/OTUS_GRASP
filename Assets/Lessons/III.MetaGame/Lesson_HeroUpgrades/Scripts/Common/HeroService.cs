using Entities;
using Game.Gameplay.Hero;
using UnityEngine;

namespace Lessons.Meta.Upgrades
{
    public sealed class HeroService : MonoBehaviour, IHeroService
    {
        [SerializeField]
        private MonoEntity hero;

        public IEntity GetHero()
        {
            return this.hero;
        }
    }
}