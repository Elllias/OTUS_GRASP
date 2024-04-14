using Game.UI;
using TMPro;
using Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta
{
    public sealed class InventoryItemPopup : MonoWindow<IInventoryItemPresentationModel>
    {
        [SerializeField]
        private TextMeshProUGUI titleText;
        
        [SerializeField]
        private TextMeshProUGUI decriptionText;
        
        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private Button consumeButton;

        [Space]
        [SerializeField]
        private StackView stackView;

        private IInventoryItemPresentationModel presenter;
        
        protected override void OnShow(IInventoryItemPresentationModel presenter)
        {
            this.presenter = presenter;

            this.titleText.text = presenter.Title;
            this.decriptionText.text = presenter.Description;
            this.iconImage.sprite = presenter.Icon;

            this.SetupStackContainer(presenter);
            this.SetupConsumeButton(presenter);
            this.consumeButton.onClick.AddListener(this.OnConsumeButtonClicked);
        }

        protected override void OnHide()
        {
            this.consumeButton.onClick.RemoveListener(this.OnConsumeButtonClicked);
        }

        private void OnConsumeButtonClicked()
        {
            this.presenter.OnConsumeClicked();
        }

        private void SetupStackContainer(IInventoryItemPresentationModel presenter)
        {
            var isStackableItem = presenter.IsStackableItem();
            this.stackView.SetVisible(isStackableItem);
            
            if (isStackableItem)
            {
                presenter.GetStackInfo(out var current, out var size);
                this.stackView.SetAmount(current, size);
            }
        }

        private void SetupConsumeButton(IInventoryItemPresentationModel presenter)
        {
            var isConsumableItem = presenter.IsConsumableItem();
            this.consumeButton.gameObject.SetActive(isConsumableItem);
            if (isConsumableItem)
            {
                this.consumeButton.interactable = presenter.CanConsumeItem();
            }
        }
    }
}