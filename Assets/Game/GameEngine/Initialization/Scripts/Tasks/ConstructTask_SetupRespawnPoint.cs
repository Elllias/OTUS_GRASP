using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Task «Setup Respawn Point»",
        menuName = "GameEngine/Construct/New Task «Setup Respawn Point»"
    )]
    public sealed class ConstructTask_SetupRespawnPoint : GameContext.ConstructTask
    {
        public override void Construct(GameContext gameContext)
        {
            var spawnPoint = GameObject.FindGameObjectWithTag("Respawn");
            if (spawnPoint == null)
            {
                Debug.LogError("Respawn Point is not found!");
            }

            var respawnInteractor = gameContext.GetService<RespawnInteractor>();
            respawnInteractor.SetupSpawnPoint(spawnPoint.transform);
        }
    }
}