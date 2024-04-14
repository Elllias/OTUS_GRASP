using System.Collections.Generic;
using Game.GameEngine.GameResources;
using Game.GameEngine.Products;
using Game.Gameplay.Player;
using Game.UI;
using GameSystem;
using Windows;
using UnityEngine;

namespace Game.Meta
{
    public sealed class ProductListPresenterOptimized : MonoWindow,
        IGameConstructElement,
        RecyclableListView.IAdapter
    {
        [SerializeField]
        private RecyclableListView recycleViewList;

        [Space]
        [SerializeField]
        private ProductCatalog productCatalog;

        [SerializeField]
        private ResourceInfoCatalog resourceCatalog;

        [SerializeField]
        private Sprite moneyIcon;

        private readonly Dictionary<RectTransform, ProductPresenter> presenterMap = new();

        private ProductBuyer buyManager;

        private MoneyStorage moneyStorage;

        private ResourceStorage resourceStorage;

        protected override void OnShow(object args)
        {
            this.recycleViewList.Initialize(adapter: this);
        }

        protected override void OnHide()
        {
            this.recycleViewList.Terminate();
        }

        int RecyclableListView.IAdapter.GetDataCount()
        {
            return this.productCatalog.ProductCount;
        }

        void RecyclableListView.IAdapter.OnCreateView(RectTransform view, int index)
        {
            var viewComponent = view.GetComponent<ProductView>();
            var presenter = new ProductPresenter(viewComponent);
            presenter.Construct(
                this.buyManager,
                this.moneyStorage,
                this.resourceStorage,
                this.resourceCatalog,
                this.moneyIcon
            );
            this.presenterMap.Add(view, presenter);

            var productConfig = this.productCatalog.GetProduct(index);
            presenter.SetProduct(productConfig.Prototype);
            presenter.Start();
        }

        void RecyclableListView.IAdapter.OnUpdateView(RectTransform view, int index)
        {
            var presenter = this.presenterMap[view];
            var productConfig = this.productCatalog.GetProduct(index);
            presenter.SetProduct(productConfig.Prototype);
        }

        void RecyclableListView.IAdapter.OnDestroyView(RectTransform view)
        {
            var presenter = this.presenterMap[view];
            presenter.Stop();
            this.presenterMap.Remove(view);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.buyManager = context.GetService<ProductBuyer>();
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.resourceStorage = context.GetService<ResourceStorage>();
        }
    }
}