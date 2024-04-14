using Entities;
using UnityEngine;

namespace Lessons.Gameplay.Common
{
    public sealed class HeroService : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity hero;

        public IEntity GetHero()
        {
            return this.hero;
        }
    }
}