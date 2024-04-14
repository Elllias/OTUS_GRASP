using GameSystem;
using Random = UnityEngine.Random;

namespace Game.Meta
{
    public sealed class MissionSelector
    {
        [GameInject]
        private MissionCatalog catalog;
        
        public MissionConfig SelectNextMission(MissionDifficulty difficulty, string excludeMissionId)
        {
            var missions = this.catalog.FindMissions(it => it.Difficulty == difficulty &&
                                                                 it.Id != excludeMissionId);
            var randomIndex = Random.Range(0, missions.Length);
            var config = missions[randomIndex];
            return config;
        }
    }
}