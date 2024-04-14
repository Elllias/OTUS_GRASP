using Lessons.Architecture.MVO;
using Lessons.Architecture.PM;

namespace Lessons.Architecture.MVP
{
    public sealed class ProductPresenter
    {
        private readonly Product product;
        
        private readonly IProductView view;
        
        private readonly ProductBuyer productBuyer;

        private readonly MoneyStorage moneyStorage;
        
        public ProductPresenter(Product product, IProductView view, ProductBuyer productBuyer, MoneyStorage moneyStorage)
        {
            this.product = product;
            this.view = view;
            this.productBuyer = productBuyer;
            this.moneyStorage = moneyStorage;
        }

        public void Start()
        {
            this.view.SetTitle(this.product.title);
            this.view.SetDescription(this.product.description);
            this.view.SetIcon(this.product.icon);
            this.view.SetPrice(this.product.price.ToString());
            this.view.SetButtonInteractible(this.productBuyer.CanBuy(this.product));
            
            this.view.AddButtonListener(this.OnBuyClicked);
            this.moneyStorage.OnMoneyChanged += this.OnMoneyChanged;
        }

        public void Stop()
        {
            this.moneyStorage.OnMoneyChanged -= this.OnMoneyChanged;
            this.view.RemoveButtonListener(this.OnBuyClicked);
        }
        
        private void OnBuyClicked()
        {
            if (this.productBuyer.CanBuy(this.product))
            {
                this.productBuyer.Buy(this.product);
            }
        }
        
        private void OnMoneyChanged(int money)
        {
            this.view.SetButtonInteractible(this.productBuyer.CanBuy(this.product));
        }
    }
}