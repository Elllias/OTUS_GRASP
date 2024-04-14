using System;
using Entities;
using Game.Gameplay.Hero;
using UnityEngine;

namespace GameNodes
{
    [Serializable]
    public sealed class HeroService : IHeroService
    {
        [SerializeField]
        private MonoEntity hero;
        
        public IEntity GetHero()
        {
            return this.hero;
        }
    }
}