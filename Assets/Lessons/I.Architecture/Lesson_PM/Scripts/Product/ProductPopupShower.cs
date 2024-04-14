using GameSystem;
using Lessons.Architecture.MVO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    
    
    public sealed class ProductPopupShower : MonoBehaviour
    {
        private PopupManager popupManager;
        
        private ProductPresentationModelFactory pmFactory;

        [GameInject]
        public void Construct(PopupManager popupManager, ProductPresentationModelFactory pmFactory)
        {
            this.popupManager = popupManager;
            this.pmFactory = pmFactory;
        }
        
        [Button]
        public void ShowPopup(Product product)
        {
            var pm = this.pmFactory.Create(product); 
            this.popupManager.ShowPopup(PopupName.PRODUCT, pm);
        }
    }
}