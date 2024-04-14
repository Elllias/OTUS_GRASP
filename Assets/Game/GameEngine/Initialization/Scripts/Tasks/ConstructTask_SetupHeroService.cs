using Entities;
using Game.GameEngine.Entities;
using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup Hero In Service»",
        menuName = "GameEngine/Construct/New Task «Setup Hero In Service»"
    )]
    public sealed class ConstructTask_SetupHeroService : GameContext.ConstructTask
    {
        [SerializeField]
        private ScriptableEntityCondition heroCondition;

        public override void Construct(GameContext gameContext)
        {
            var entitiesService = gameContext.GetService<EntitiesService>();
            if (entitiesService.FindEntity(this.heroCondition, out IEntity hero))
            {
                var heroService = gameContext.GetService<HeroService>();
                heroService.SetupHero(hero);
            }
        }
    }
}