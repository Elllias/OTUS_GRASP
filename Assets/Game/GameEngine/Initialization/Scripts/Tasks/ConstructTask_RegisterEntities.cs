using Game.GameEngine.Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Register Entities»",
        menuName = "GameEngine/Construct/New Task «Register Entities»"
    )]
    public sealed class ConstructTask_RegisterEntities : GameContext.ConstructTask
    {
        public override void Construct(GameContext gameContext)
        {
            var entitiesService = gameContext.GetService<EntitiesService>();

            var providers = FindObjectsOfType<EntitiesProvider>();
            for (int i = 0, count = providers.Length; i < count; i++)
            {
                var provider = providers[i];
                var entities = provider.ProvideEntities();
                entitiesService.AddEntities(entities);
            }
        }
    }
}