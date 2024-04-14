using System;
using Game.GameEngine.Mechanics;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HeroModel_Canvas
    {
        [SerializeField]
        private HitPointsBar hitPointsBar;

        private readonly HitPointsBarAdapterV2 hitPointsBarAdapterV2 = new();

        [Construct]
        private void Construct(HeroModel_Core core, MonoBehaviour monoContext)
        {
            this.hitPointsBarAdapterV2.Construct(core.life.hitPoints, this.hitPointsBar, monoContext);
        }
    }
}