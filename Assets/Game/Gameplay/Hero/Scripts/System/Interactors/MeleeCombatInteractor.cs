using System;
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class MeleeCombatInteractor : IGameInitElement
    {
        private HeroService heroService;

        private MonoBehaviour monoContext;

        [SerializeField]
        private float delay = 0.15f;

        private IComponent_MeleeCombat heroComponent;

        private Coroutine delayCoroutine;

        [GameInject]
        public void Construct(HeroService heroService, MonoBehaviour monoContext)
        {
            this.heroService = heroService;
            this.monoContext = monoContext;
        }

        public void TryStartCombat(IEntity target)
        {
            if (this.heroComponent.IsCombat)
            {
                return;
            }

            if (this.delayCoroutine == null)
            {
                this.delayCoroutine = this.monoContext.StartCoroutine(this.CombatRoutine(target));
            }
        }

        private IEnumerator CombatRoutine(IEntity target)
        {
            yield return new WaitForSeconds(this.delay);

            var operation = new CombatOperation(target);
            if (this.heroComponent.CanStartCombat(operation))
            {
                this.heroComponent.StartCombat(operation);
            }

            this.delayCoroutine = null;
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_MeleeCombat>();
        }
    }
}