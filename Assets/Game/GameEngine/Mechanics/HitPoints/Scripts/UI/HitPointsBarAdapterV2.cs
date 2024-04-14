using System.Collections;
using Declarative;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class HitPointsBarAdapterV2 :
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private IHitPoints hitPoints;

        private HitPointsBar view;

        private MonoBehaviour context;

        private Coroutine hideCoroutine;

        public void Construct(IHitPoints hitPoints, HitPointsBar view, MonoBehaviour context)
        {
            this.hitPoints = hitPoints;
            this.view = view;
            this.context = context;
        }

        void IAwakeListener.Awake()
        {
            this.SetupBar();
        }

        void IEnableListener.OnEnable()
        {
            this.hitPoints.OnSetuped += this.SetupBar;
            this.hitPoints.OnCurrentPointsChanged += this.UpdateBar;
        }

        void IDisableListener.OnDisable()
        {
            this.hitPoints.OnSetuped -= this.SetupBar;
            this.hitPoints.OnCurrentPointsChanged -= this.UpdateBar;
        }

        private void SetupBar()
        {
            this.ResetCoroutines();

            var hitPoints = this.hitPoints.Current;
            var maxHitPoints = this.hitPoints.Max;

            var showBar = hitPoints > 0 && hitPoints < maxHitPoints;
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            this.ResetCoroutines();

            var maxHitPoints = this.hitPoints.Max;

            this.view.SetVisible(true);
            this.view.SetHitPoints(hitPoints, maxHitPoints);

            if (hitPoints <= 0 || hitPoints == maxHitPoints)
            {
                this.hideCoroutine = this.context.StartCoroutine(this.HideWithDelay());
            }
        }

        private void ResetCoroutines()
        {
            if (this.hideCoroutine != null)
            {
                this.context.StopCoroutine(this.hideCoroutine);
                this.hideCoroutine = null;
            }
        }

        private IEnumerator HideWithDelay()
        {
            yield return new WaitForSeconds(1.0f);
            this.view.SetVisible(false);
            this.hideCoroutine = null;
        }
    }
}