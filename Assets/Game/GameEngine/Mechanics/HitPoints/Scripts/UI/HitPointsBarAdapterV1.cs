using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class HitPointsBarAdapterV1 :
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private IHitPoints hitPointsEngine;

        private HitPointsBar view;
        
        public void Construct(IHitPoints hitPointsEngine, HitPointsBar view)
        {
            this.hitPointsEngine = hitPointsEngine;
            this.view = view;
        }

        void IAwakeListener.Awake()
        {
            this.SetupBar();
        }

        void IEnableListener.OnEnable()
        {
            this.hitPointsEngine.OnCurrentPointsChanged += this.OnHitPointsChanged;
        }

        void IDisableListener.OnDisable()
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