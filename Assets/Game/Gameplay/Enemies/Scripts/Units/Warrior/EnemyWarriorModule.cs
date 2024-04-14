using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public sealed class EnemyWarriorModule : GameModule
    {
        [Space]
        [SerializeField]
        private MonoEntity unit;

        [SerializeField]
        private MonoEntity ai;

        [SerializeField]
        private float respawnTime = 5.0f;

        [GameElement]
        private GameElement_SwitchEnableComponents enableController = new();

        [ShowInInspector, ReadOnly, Space]
        [GameElement]
        private EnemyRespawnController respawnController = new();

        public override void ConstructGame(GameContext context)
        {
            this.enableController.Construct(this.unit, this.ai);
            this.respawnController.Construct(this.unit, this.ai, this.respawnTime, this.transform);
        }
    }
}