using System.Collections;
using Entities;
using GameSystem;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using UnityEngine;

namespace Lessons.Tutorial
{
    public sealed class StepObserver_KillEnemy : StepObserver
    {
        private Provider_TargetEnemy enemyProvider;

        private IEntity hero;

        protected override void InitGame(GameContext context, bool isStepPassed)
        {
            this.enemyProvider.TargetEnemy.gameObject.SetActive(false);
            
            this.enemyProvider = context.GetService<Provider_TargetEnemy>();
            this.hero = context.GetService<HeroService>().GetHero();
        }

        protected override void OnStartStep()
        {
            this.hero.Get<IComponent_MeleeCombat>().OnCombatStopped += this.HeroCombatFinished;
            this.enemyProvider.TargetEnemy.gameObject.SetActive(true);
        }

        protected override void OnFinishStep()
        {
            this.hero.Get<IComponent_MeleeCombat>().OnCombatStopped -= this.HeroCombatFinished;
            this.StartCoroutine(this.HideEnemy());
        }

        private IEnumerator HideEnemy()
        {
            yield return new WaitForSeconds(1.5f);
            this.enemyProvider.TargetEnemy.gameObject.SetActive(false);
        }

        private void HeroCombatFinished(CombatOperation operation)
        {
            if (operation.targetDestroyed && ReferenceEquals(operation.targetEntity, this.enemyProvider.TargetEnemy))
            {
                Debug.Log("COMBAT STEP FINIHED");
                this.FinishStepAndMoveNext();
            }
        }
    }
}