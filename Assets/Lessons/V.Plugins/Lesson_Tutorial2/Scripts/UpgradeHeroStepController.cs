using Game.GameEngine;
using Game.Gameplay.Player;
using Game.Meta;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;
using GameSystem;
using Windows;
using UnityEngine;
using PopupManager = Game.Tutorial.UI.PopupManager;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    [AddComponentMenu("Step «Upgrade Hero»")]
    public sealed class UpgradeHeroStepController : TutorialStepController, IGameInitElement
    {
        private WorldPlaceVisitInteractor placeVisitor;

        private PointerManager pointerManager;

        private NavigationManager navigationManager;

        private PopupManager popupManager;

        private WorldPlacePopupShower popupShower;

        private readonly UpgradeInspector upgradeInspector = new();

        [SerializeField]
        private UpgradeHeroPanelShower panelShower;

        [SerializeField]
        private UpgradeHeroStepConfig stepConfig;

        [Space]
        [SerializeField]
        private Transform upgradePoint;

        [SerializeField]
        private MonoWindow popupPrefab;

        public override void ConstructGame(GameContext context)
        {
            base.ConstructGame(context);
            this.placeVisitor = context.GetService<WorldPlaceVisitInteractor>();
            this.pointerManager = context.GetService<PointerManager>();
            this.navigationManager = context.GetService<NavigationManager>();
            this.popupManager = context.GetService<PopupManager>();
            
            var screenTransform = context.GetService<ScreenTransform>();
            this.panelShower.Construct(this.stepConfig, screenTransform);

            var upgradesManager = context.GetService<UpgradesManager>();
            this.upgradeInspector.Construct(this.stepConfig, upgradesManager);

            this.popupShower = context.GetService<WorldPlacePopupShower>();
        }

        void IGameInitElement.InitGame()
        {
            if (!this.IsStepFinished())
            {
                this.popupShower.SetEnable(false);
            }
        }

        protected override void OnStart()
        {
            //Точка входа:
            this.placeVisitor.OnVisitStarted += this.OnPlaceVisited;
            
            this.pointerManager.ShowPointer(this.upgradePoint);
            this.navigationManager.StartLookAt(this.upgradePoint);
            this.panelShower.Show();
        }

        private void OnPlaceVisited(WorldPlaceType placeType)
        {
            if (placeType != WorldPlaceType.BLACKSMITH)
            {
                return;
            }

            this.placeVisitor.OnVisitStarted -= this.OnPlaceVisited;
            this.pointerManager.HidePointer();
            this.navigationManager.Stop();
            this.panelShower.Hide();

            this.popupManager.Show(this.popupPrefab);
            this.upgradeInspector.InspectUpgrade(this.NotifyAboutComplete);
        }

        protected override void OnStop()
        {
            this.popupShower.SetEnable(true);
        }
    }
}