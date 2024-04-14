using Game.GameEngine.Mechanics;
using Game.GameEngine.Products;
using Game.Gameplay.Player;

namespace Game.Meta
{
    public sealed class ProductBuyProcessor_SpendMoney : IProductBuyProcessor 
    {
        private readonly MoneyStorage moneyStorage;

        public ProductBuyProcessor_SpendMoney(MoneyStorage moneyStorage)
        {
            this.moneyStorage = moneyStorage;
        }

        public void ProcessBuy(Product product)
        {
            if (product.TryGetComponent(out IComponent_MoneyPrice component))
            {
                this.moneyStorage.SpendMoney(component.Price);
            }
        }
    }
}