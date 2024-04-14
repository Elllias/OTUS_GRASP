using System.Collections;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Hit Points Bar Adapter V2")]
    public sealed class UHitPointsBarAdapterV2 : MonoBehaviour
    {
        [SerializeField]
        private UHitPoints hitPointsEngine;

        [SerializeField]
        private HitPointsBar view;

        private Coroutine hideCoroutine;

        private void Awake()
        {
            this.SetupBar();
        }

        private void OnEnable()
        {
            this.hitPointsEngine.OnSetuped += this.SetupBar;
            this.hitPointsEngine.OnCurrentPointsChanged += this.UpdateBar;
        }

        private void OnDisable()
        {
            this.hitPointsEngine.OnSetuped -= this.SetupBar;
            this.hitPointsEngine.OnCurrentPointsChanged -= this.UpdateBar;
        }

        private void SetupBar()
        {
            this.ResetCoroutines();

            var hitPoints = this.hitPointsEngine.Current;
            var maxHitPoints = this.hitPointsEngine.Max;
            
            var showBar = hitPoints > 0 && hitPoints < maxHitPoints;
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            this.ResetCoroutines();

            var maxHitPoints = this.hitPointsEngine.Max;
            
            this.view.SetVisible(true);
            this.view.SetHitPoints(hitPoints, maxHitPoints);

            if (hitPoints <= 0 || hitPoints == maxHitPoints)
            {
                this.hideCoroutine = this.StartCoroutine(this.HideWithDelay());
            }
        }
        
        private void ResetCoroutines()
        {
            if (this.hideCoroutine != null)
            {
                this.StopCoroutine(this.hideCoroutine);
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