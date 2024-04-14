using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Gameplay.Vendors
{
    [AddComponentMenu("Gameplay/Vendors/Vendor Info Widget")]
    public sealed class InfoWidget : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private TextMeshProUGUI priceText;

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }

        public void SetPrice(string price)
        {
            this.priceText.text = price;
        }
    }
}