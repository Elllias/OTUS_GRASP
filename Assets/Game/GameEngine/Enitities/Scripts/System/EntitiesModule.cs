using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public sealed class EntitiesModule : GameModule
    {
        [GameService]
        [Space, ReadOnly, ShowInInspector]
        private EntitySpawner spawner = new();

        [GameService]
        [ReadOnly, ShowInInspector]
        private EntityDestroyer destroyer = new();

        [GameService]
        [ReadOnly, ShowInInspector]
        private EntitiesService entitiesService = new();
    }
}