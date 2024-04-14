using Game.Gameplay.Hero;
using Game.Tutorial.App;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using Services;
using UnityEngine;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Step «Harvest Resource»")]
    public sealed class HarvestResourceStepController : TutorialStepController
    {
        private PointerManager pointerManager;

        private ScreenTransform screenTransform;
        
        private readonly HarvestResourceInspector inspector = new();

        [SerializeField]
        private HarvestResourceConfig config;

        [SerializeField]
        private HarvestResourcePanelShower panelShower = new();

        [SerializeField]
        private Transform pointerTransform;

        public override void ConstructGame(GameContext context)
        {
            this.pointerManager = context.GetService<PointerManager>();
            this.screenTransform = context.GetService<ScreenTransform>();

            var heroService = context.GetService<IHeroService>();
            this.inspector.Construct(heroService, this.config);
            this.panelShower.Construct(this.config);

            base.ConstructGame(context);
        }

        protected override void OnStart()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_2__harvest_resource_started");
            this.inspector.Inspect(callback: this.NotifyAboutCompleteAndMoveNext);
            this.pointerManager.ShowPointer(this.pointerTransform.position, this.pointerTransform.rotation);
            this.panelShower.Show(this.screenTransform.Value);
        }

        protected override void OnStop()
        {
            TutorialAnalytics.LogEventAndCache("tutorial_step_2__harvest_resource_completed");
            this.panelShower.Hide();
            this.pointerManager.HidePointer();
        }
    }
}