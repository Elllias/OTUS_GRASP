using System.Collections.Generic;
using GameSystem;
using Lessons.Architecture.MVO;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Lessons.Architecture.MVP
{
    public sealed class ProductListAdapter : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private ProductView viewPrefab;
        
        [SerializeField]
        private Transform container;

        [SerializeField]
        private ProductCatalog productCatalog;

        private readonly List<ViewHolder> viewHolders = new();

        private MoneyStorage moneyStorage;

        private ProductBuyer productBuyer;

        public void Show()
        {
            var products = this.productCatalog.products;
            for (int i = 0, count = products.Length; i < count; i++)
            {
                Product product = products[i];
                this.ShowProduct(product);
            }
        }
        
        public void Hide()
        {
            for (int i = 0, count = this.viewHolders.Count; i < count; i++)
            {
                var vh = this.viewHolders[i];
                this.HideProduct(vh);
            }
            
            this.viewHolders.Clear();
        }

        private void ShowProduct(Product product)
        {
            ProductView view = Instantiate(this.viewPrefab, this.container);
            ProductPresenter presenter = new ProductPresenter(product, view, this.productBuyer, this.moneyStorage);
            presenter.Start();

            this.viewHolders.Add(new ViewHolder(view, presenter));
        }

        private void HideProduct(ViewHolder vh)
        {
            vh.presenter.Stop();
            Destroy(vh.view.gameObject);
        }
        
        private readonly struct ViewHolder
        {
            public readonly ProductView view;
            public readonly ProductPresenter presenter;

            public ViewHolder(ProductView view, ProductPresenter presenter)
            {
                this.view = view;
                this.presenter = presenter;
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
            this.productBuyer = context.GetService<ProductBuyer>();
            Debug.Log("Construct!");
        }
    }
}