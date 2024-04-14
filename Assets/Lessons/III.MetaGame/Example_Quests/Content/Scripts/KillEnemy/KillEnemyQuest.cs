using System;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;

namespace Lessons.Meta
{
    public sealed class KillEnemyQuest : Quest, IGameConstructElement
    {
        public override event Action<Quest, float> OnProgressChanged;
        
        [ReadOnly]
        [ShowInInspector]
        [PropertySpace(8)]
        public int CurrentKills { get; set; }

        [ReadOnly]
        [ShowInInspector]
        public int RequiredKills
        {
            get { return this.config.requiredKills; }
        }

        public override float Progress
        {
            get { return (float) this.CurrentKills / this.RequiredKills; }
        }

        public override string TextProgress
        {
            get { return $"{this.CurrentKills}/{this.RequiredKills}"; }
        }

        private readonly KillEnemyQuestConfig config;

        private IHeroService heroService;
        
        public KillEnemyQuest(KillEnemyQuestConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnStart()
        {
            this.heroService.GetHero().Get<IComponent_MeleeCombat>().OnCombatStopped += this.OnCombatFinished; 
        }

        protected override void OnEnd()
        {
            this.heroService.GetHero().Get<IComponent_MeleeCombat>().OnCombatStopped -= this.OnCombatFinished;
        }

        private void OnCombatFinished(CombatOperation operation)
        {
            if (operation.targetDestroyed)
            {
                this.CurrentKills = Math.Min(this.CurrentKills + 1, this.RequiredKills);
                this.OnProgressChanged?.Invoke(this, this.Progress);
                this.TryComplete();
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.heroService = context.GetService<IHeroService>();
        }
    }
}