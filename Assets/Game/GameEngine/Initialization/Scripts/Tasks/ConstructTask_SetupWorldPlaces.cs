using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup World Places»",
        menuName = "GameEngine/Construct/New Task «Setup World Places»"
    )]
    public class ConstructTask_SetupWorldPlaces : GameContext.ConstructTask
    {
        public override void Construct(GameContext gameContext)
        {
            var worldPlaces = FindObjectsOfType<WorldPlaceObject>();
            var service = gameContext.GetService<WorldPlaceService>();
            service.Setup(worldPlaces);
        }
    }
}