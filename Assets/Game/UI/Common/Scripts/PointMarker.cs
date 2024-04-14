using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public sealed class PointMarker : MonoBehaviour
    {
        [SerializeField]
        private GameObject root;

        [SerializeField]
        private Image iconImage;

        public void SetIcon(Sprite icon)
        {
            this.iconImage.sprite = icon;
        }
        
        public void Show()
        {
            this.root.SetActive(true);
        }

        public void Hide()
        {
            this.root.SetActive(false);
        }
    }
}