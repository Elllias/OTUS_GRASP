using Game.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Lessons.Architecture.MVP
{
    public sealed class ProductView : MonoBehaviour, IProductView
    {
        [SerializeField]
        private TMP_Text titleText;

        [SerializeField]
        private TMP_Text descriptionText;

        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private BuyButton buyButton;
        
        public void AddButtonListener(UnityAction action)
        {
            this.buyButton.AddListener(action);
        }

        public void RemoveButtonListener(UnityAction action)
        {
            this.buyButton.RemoveListener(action);
        }

        public void SetTitle(string title)
        {
            this.titleText.text = title;
        }

        public void SetDescription(string description)
        {
            this.descriptionText.text = description;
        }

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }

        public void SetPrice(string price)
        {
            this.buyButton.SetPrice(price);
        }

        public void SetButtonInteractible(bool interactible)
        {
            this.buyButton.SetAvailable(interactible);
        }
    }
}