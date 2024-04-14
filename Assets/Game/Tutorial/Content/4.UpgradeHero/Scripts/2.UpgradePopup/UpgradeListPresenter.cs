using System;
using System.Collections.Generic;
using System.Linq;
using Game.Gameplay.Player;
using Game.Meta;
using GameSystem;
using UnityEngine;

namespace Game.Tutorial
{
    public sealed class UpgradeListPresenter : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private UpgradeHeroConfig config;

        [SerializeField]
        private UpgradeView targetView;

        [SerializeField]
        private UpgradeView[] otherViews;

        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        private readonly List<UpgradePresenter> presenters;

        public UpgradeListPresenter()
        {
            this.presenters = new List<UpgradePresenter>();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.upgradesManager = context.GetService<UpgradesManager>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }

        public void Show()
        {
            this.InitUpgrades();
            this.ShowUpgrades();
        }

        public void Hide()
        {
            this.HideUpgrades();
            this.presenters.Clear();
        }

        private void InitUpgrades()
        {
            var targetId = this.config.upgradeConfig.id;
            var targetUprade = this.upgradesManager.GetUpgrade(targetId);
            this.CreatePresenter(targetUprade, this.targetView);

            var otherUpgrades = this.upgradesManager
                .GetAllUpgrades()
                .Where(it => it.Id != targetId)
                .ToArray();

            var otherCount = Math.Min(this.otherViews.Length, otherUpgrades.Length);
           
            for (var i = 0 ; i < otherCount; i++)
            {
                var upgrade = otherUpgrades[i];
                var view = this.otherViews[i];
                this.CreatePresenter(upgrade, view);
            }
        }

        private void CreatePresenter(Upgrade targetUprade, UpgradeView view)
        {
            var targetPresenter = new UpgradePresenter(targetUprade, view);
            targetPresenter.Construct(this.upgradesManager, this.moneyStorage);
            this.presenters.Add(targetPresenter);
        }

        private void ShowUpgrades()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        private void HideUpgrades()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();
            }
        }
    }
}