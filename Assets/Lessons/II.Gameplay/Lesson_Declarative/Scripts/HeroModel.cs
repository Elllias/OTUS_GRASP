using Declarative;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    public sealed class HeroModel : DeclarativeModel
    {
        [SerializeField]
        public HeroConfig config;
        
        [Section]
        [SerializeField]
        public HeroModel_Life life;

        [Section]
        [SerializeField]
        public HeroModel_Move move;
        
        [Section]
        [SerializeField]
        public HeroModel_Components components;
    }
}