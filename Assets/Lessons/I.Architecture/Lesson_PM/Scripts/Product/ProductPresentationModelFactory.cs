using GameSystem;
using Lessons.Architecture.MVO;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class ProductPresentationModelFactory : MonoBehaviour
    {
        private ProductBuyer productBuyer;

        private MoneyStorage moneyStorage;
        
        [GameInject]
        public void Construct(ProductBuyer productBuyer, MoneyStorage moneyStorage)
        {
            this.productBuyer = productBuyer;
            this.moneyStorage = moneyStorage;
        }
        
        public IProductPresentationModel Create(Product product)
        {
            return new ProductPresentationModel(product, this.productBuyer, this.moneyStorage);
        }
    }
}