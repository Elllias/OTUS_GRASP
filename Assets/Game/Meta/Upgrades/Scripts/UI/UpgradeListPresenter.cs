using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Windows;
using UnityEngine;

namespace Game.Meta
{
    [AddComponentMenu(UpgradeExtensions.MENU_PATH + "Upgrade List Presenter")]
    public sealed class UpgradeListPresenter : MonoWindow, IGameConstructElement
    {
        [SerializeField]
        private UpgradeView viewPrefab;

        [SerializeField]
        private Transform viewsContainer;
        
        private UpgradesManager upgradesManager;

        private MoneyStorage moneyStorage;

        private readonly List<UpgradePresenter> presenters;

        private readonly List<UpgradeView> views;

        public UpgradeListPresenter()
        {
            this.presenters = new List<UpgradePresenter>();
            this.views = new List<UpgradeView>();
        }

        protected override void OnShow(object args)
        {
            this.CreateUpgrades();
            this.ShowUpgrades();
        }

        protected override void OnHide()
        {
            this.DestroyUpgrades();
        }

        private void CreateUpgrades()
        {
            var upgrades = this.upgradesManager.GetAllUpgrades();
            for (int i = 0, count = upgrades.Length; i < count; i++)
            {
                var view = Instantiate(this.viewPrefab, this.viewsContainer);
                this.views.Add(view);

                var model = upgrades[i];
                var presenter = new UpgradePresenter(model, view);
                presenter.Construct(this.upgradesManager, this.moneyStorage);
                this.presenters.Add(presenter);
            }
        }

        private void ShowUpgrades()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        private void DestroyUpgrades()
        {
            var count = this.presenters.Count;
            for (var i = 0; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();

                var view = this.views[i];
                Destroy(view.gameObject); //Можно кэшировать
            }

            this.presenters.Clear();
            this.views.Clear();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.upgradesManager = context.GetService<UpgradesManager>();
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}