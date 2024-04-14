using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Hit Points Bar Adapter V1")]
    public sealed class UHitPointsBarAdapterV1 : MonoBehaviour
    {
        [SerializeField]
        private UHitPoints hitPointsEngine;

        [SerializeField]
        private HitPointsBar view;

        private void Awake()
        {
            this.SetupBar();
        }

        private void OnEnable()
        {
            this.hitPointsEngine.OnCurrentPointsChanged += this.OnHitPointsChanged;
        }

        private void OnDisable()
        {
            this.hitPointsEngine.OnCurrentPointsChanged -= this.OnHitPointsChanged;
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            this.UpdateBar(hitPoints);
        }

        private void SetupBar()
        {
            var hitPoints = this.hitPointsEngine.Current;
            var maxHitPoints = this.hitPointsEngine.Max;
            
            var showBar = hitPoints > 0;
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }

        private void UpdateBar(int hitPoints)
        {
            var maxHitPoints = this.hitPointsEngine.Max;
            var showBar = hitPoints > 0;
            
            this.view.SetVisible(showBar);
            this.view.SetHitPoints(hitPoints, maxHitPoints);
        }
    }
}