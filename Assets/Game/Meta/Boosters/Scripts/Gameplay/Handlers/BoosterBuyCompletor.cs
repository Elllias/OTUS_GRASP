using Game.GameEngine.Products;

namespace Game.Meta
{
    public sealed class BoosterBuyCompletor : IProductBuyCompletor
    {
        private readonly BoostersManager boostersManager;

        public BoosterBuyCompletor(BoostersManager boostersManager)
        {
            this.boostersManager = boostersManager;
        }

        void IProductBuyCompletor.CompleteBuy(Product product)
        {
            if (product.TryGetComponent(out IComponent_BoosterInfo component))
            {
                this.boostersManager.LaunchBooster(component.BoosterInfo);
            }
        }
    }
}