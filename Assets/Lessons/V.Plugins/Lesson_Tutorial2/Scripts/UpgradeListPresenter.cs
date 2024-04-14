using System.Collections.Generic;
using System.Linq;
using Game.Gameplay.Player;
using Game.Meta;
using GameSystem;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    public sealed class UpgradeListPresenter : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private UpgradeHeroStepConfig stepConfig;

        [Space]
        [SerializeField]
        private UpgradeView targetView;

        [SerializeField]
        private UpgradeView[] otherViews;

        private readonly List<UpgradePresenter> presenters = new();

        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        public void Show()
        {
            var targetUpgradeId = this.stepConfig.targetUpgrade.id;
            var targetUpgrade = this.upgradesManager.GetUpgrade(targetUpgradeId);
            var targetPresenter = new UpgradePresenter(targetUpgrade, this.targetView);
            targetPresenter.Construct(this.upgradesManager, this.moneyStorage);
            targetPresenter.Start();
            this.presenters.Add(targetPresenter);

            var otherUpgrades = this.upgradesManager
                .GetAllUpgrades()
                .Where(it => it.Id != targetUpgradeId)
                .ToArray();

            for (int i = 0, count = this.otherViews.Length; i < count; i++)
            {
                var view = this.otherViews[i];
                var upgrade = otherUpgrades[i];
                var presenter = new UpgradePresenter(upgrade, view);
                presenter.Construct(this.upgradesManager, this.moneyStorage);
                presenter.Start();
                this.presenters.Add(presenter);
            }
        }

        public void Hide()
        {
            foreach (var presenter in this.presenters)
            {
                presenter.Stop();
            }
            
            this.presenters.Clear();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.upgradesManager = context.GetService<UpgradesManager>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}