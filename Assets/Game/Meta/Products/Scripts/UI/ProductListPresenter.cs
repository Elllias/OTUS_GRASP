using System.Collections.Generic;
using Game.GameEngine.GameResources;
using Game.GameEngine.Products;
using Game.Gameplay.Player;
using GameSystem;
using Windows;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductListPresenter : MonoWindow, IGameConstructElement
    {
        [SerializeField]
        private ProductView viewPrefab;

        [SerializeField]
        private Transform container;

        [Space]
        [SerializeField]
        private ProductCatalog productCatalog;

        [SerializeField]
        private ResourceInfoCatalog resourceCatalog;

        [SerializeField]
        private Sprite moneyIcon;

        private readonly List<ProductPresenter> presenters = new();

        protected override void OnShow(object args)
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Start();
            }
        }

        protected override void OnHide()
        {
            for (int i = 0, count = this.presenters.Count; i < count; i++)
            {
                var presenter = this.presenters[i];
                presenter.Stop();
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.CreateProducts(context);
        }

        private void CreateProducts(GameContext context)
        {
            var buyManager = context.GetService<ProductBuyer>();
            var moneyStorage = context.GetService<MoneyStorage>();
            var resourceStorage = context.GetService<ResourceStorage>();

            var productConfigs = this.productCatalog.GetAllProducts();
            for (int i = 0, count = productConfigs.Length; i < count; i++)
            {
                var config = productConfigs[i];
                var view = Instantiate(this.viewPrefab, this.container);
                
                var presenter = new ProductPresenter(view);
                presenter.Construct(buyManager, moneyStorage, resourceStorage, this.resourceCatalog, this.moneyIcon);
                presenter.SetProduct(config.Prototype);
                
                this.presenters.Add(presenter);
            }
        }
    }
}