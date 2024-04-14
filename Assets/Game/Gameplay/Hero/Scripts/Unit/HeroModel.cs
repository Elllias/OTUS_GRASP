using Declarative;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroModel : DeclarativeModel
    {
        [Section]
        public ScriptableHero hero;

        [Space]
        [Section]
        public HeroModel_Core core;

        [Section]
        public HeroModel_Components components;

        [Section]
        public HeroModel_Collision collision;

        [Section]
        public HeroModel_States states;

        [Section]
        public HeroModel_Animations animations;

        [Section]
        public HeroModel_Canvas canvas;

        [Section]
        public new HeroModel_Audio audio;
    }
}