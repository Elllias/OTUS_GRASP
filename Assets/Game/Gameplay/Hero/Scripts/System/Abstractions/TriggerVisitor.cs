using System;
using System.Collections;
using Elementary;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public abstract class TriggerVisitor<T> : TriggerObserver<T> where T : class
    {
        protected MonoBehaviour monoContext;
        
        [Space]
        [ReadOnly]
        [ShowInInspector]
        private T target;

        [ReadOnly]
        [ShowInInspector]
        protected bool IsVisiting { get; private set; }

        [SerializeField]
        private float checkConditionPeriod = 0.1f;

        private Coroutine updateRoutine;

        protected abstract bool CanEnter(T target);

        protected abstract ICondition ProvideConditions(T target);

        [GameInject]
        public void Construct(MonoBehaviour monoContext)
        {
            this.monoContext = monoContext;
        }

        protected sealed override void OnHeroEntered(T target)
        {
            if (this.target != null || !this.CanEnter(target))
            {
                return;
            }

            this.target = target;
            this.updateRoutine = this.monoContext.StartCoroutine(this.UpdateVisitState(target));
        }

        protected sealed override void OnHeroExited(T target)
        {
            if (!ReferenceEquals(this.target, target))
            {
                return;
            }

            if (this.updateRoutine != null)
            {
                this.monoContext.StopCoroutine(this.updateRoutine);
                this.updateRoutine = null;
            }

            if (this.IsVisiting)
            {
                this.IsVisiting = false;
                this.OnHeroQuit(this.target);
            }

            this.target = null;
        }

        protected abstract void OnHeroVisit(T target);

        protected abstract void OnHeroQuit(T target);

        private IEnumerator UpdateVisitState(T target)
        {
            WaitForSeconds period = null;
            
            if (this.checkConditionPeriod > 0.0f)
            {
                period = new WaitForSeconds(this.checkConditionPeriod);
            }

            var visitCondition = this.ProvideConditions(target);

            while (true)
            {
                var visitStarted = visitCondition.IsTrue();
                if (visitStarted && !this.IsVisiting)
                {
                    this.IsVisiting = true;
                    this.OnHeroVisit(this.target);
                }
                else if (!visitStarted && this.IsVisiting)
                {
                    this.IsVisiting = false;
                    this.OnHeroQuit(this.target);
                    visitCondition = this.ProvideConditions(target);
                }

                yield return period;
            }
        }
    }
}