using System;
using Game.Tutorial.Gameplay;
using Game.Tutorial.UI;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    [Serializable]
    public sealed class UpgradeHeroPanelShower : InfoPanelShower
    {
        private UpgradeHeroStepConfig config;

        private ScreenTransform screenTransform;

        public void Construct(
            UpgradeHeroStepConfig config,
            ScreenTransform screenTransform
        )
        {
            this.config = config;
            this.screenTransform = screenTransform;
        }

        public void Show()
        {
            this.Show(this.screenTransform.Value);
        }

        protected override void OnShow()
        {
            this.view.SetIcon(this.config.icon);
            this.view.SetTitle(this.config.title);
        }
    }
}