using System;
using Entities;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Game.GameEngine;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class KillEnemyMission : Mission 
    {
        public override event Action<Mission> OnProgressChanged;

        [ReadOnly]
        [ShowInInspector]
        [PropertySpace(8)]
        public int CurrentKills { get; private set; }

        [ReadOnly]
        [ShowInInspector]
        public int RequiredKills
        {
            get { return this.config.RequiredKills; }
        }

        public override float NormalizedProgress
        {
            get { return (float) this.CurrentKills / this.RequiredKills; }
        }

        public override string TextProgress
        {
            get { return $"{this.CurrentKills}/{this.RequiredKills}"; }
        }

        private readonly KillEnemyMissionConfig config;

        [GameInject]
        private IHeroService heroService;

        public KillEnemyMission(KillEnemyMissionConfig config) : base(config)
        {
            this.config = config;
        }

        public void Setup(int currentKills)
        {
            this.CurrentKills = currentKills;
        }

        protected override void OnStart()
        {
            this.heroService.GetHero().Get<IComponent_MeleeCombat>().OnCombatStopped += this.OnCombatFinished;
        }

        protected override void OnStop()
        {
            this.heroService.GetHero().Get<IComponent_MeleeCombat>().OnCombatStopped -= this.OnCombatFinished;                        
        }

        private void OnCombatFinished(CombatOperation operation)
        {
            if (operation.targetDestroyed)
            {
                this.CurrentKills++;
                this.OnProgressChanged?.Invoke(this);
                this.TryComplete();
            }
        }
    }
}