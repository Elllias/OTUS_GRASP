using System;
using Lessons.Architecture.MVO;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ProductPresentationModel : IProductPresentationModel
    {
        public event Action OnStateChanged;

        private readonly Product product;

        private readonly ProductBuyer productBuyer;

        private readonly MoneyStorage moneyStorage;

        public ProductPresentationModel(Product product, ProductBuyer productBuyer, MoneyStorage moneyStorage)
        {
            this.product = product;
            this.productBuyer = productBuyer;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.moneyStorage.OnMoneyChanged += this.OnMoneyChanged;
        }

        public void Stop()
        {
            this.moneyStorage.OnMoneyChanged -= this.OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            this.OnStateChanged?.Invoke();
        }

        public string GetTitle()
        {
            return this.product.title;
        }

        public string GetDescription()
        {
            return this.product.description;
        }

        public Sprite GetIcon()
        {
            return this.product.icon;
        }

        public string GetPrice()
        {
            return this.product.price.ToString();
        }

        public bool CanBuy()
        {
            return this.productBuyer.CanBuy(this.product);
        }

        public void OnBuyClicked()
        {
            if (this.productBuyer.CanBuy(this.product))
            {
                this.productBuyer.Buy(this.product);
            }
        }
    }
}