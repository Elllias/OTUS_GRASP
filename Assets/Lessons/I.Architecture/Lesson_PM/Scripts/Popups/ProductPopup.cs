using System;
using Game.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture.PM
{
    public sealed class ProductPopup : Popup //TODO: Popup<T>
    {
        [SerializeField]
        private TMP_Text title;

        [SerializeField]
        private TextMeshProUGUI description;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private BuyButton buyButton;

        [SerializeField]
        private Button closeButton;

        private IProductPresentationModel presentationModel;

        protected override void OnShow(object args)
        {
            if (args is not IProductPresentationModel presentationModel)
            {
                throw new Exception("Expected presentation model!");
            }

            this.presentationModel = presentationModel;
            
            this.title.text = this.presentationModel.GetTitle();
            this.description.text = this.presentationModel.GetDescription();
            this.icon.sprite = this.presentationModel.GetIcon();

            this.buyButton.SetPrice(this.presentationModel.GetPrice());
            this.buyButton.SetAvailable(this.presentationModel.CanBuy());

            this.buyButton.AddListener(this.OnBuyClicked);
            this.closeButton.onClick.AddListener(this.OnCloseClicked);

            this.presentationModel.OnStateChanged += this.OnStateChanged;
            this.presentationModel.Start();
        }

        protected override void OnHide()
        {
            this.buyButton.RemoveListener(this.OnBuyClicked);
            this.closeButton.onClick.RemoveListener(this.OnCloseClicked);

            this.presentationModel.OnStateChanged -= this.OnStateChanged;
            this.presentationModel.Stop();
        }

        private void OnStateChanged()
        {
            this.buyButton.SetAvailable(this.presentationModel.CanBuy());
        }

        private void OnBuyClicked()
        {
            this.presentationModel.OnBuyClicked();
        }

        private void OnCloseClicked()
        {
            this.RequestClose();
        }
    }
}