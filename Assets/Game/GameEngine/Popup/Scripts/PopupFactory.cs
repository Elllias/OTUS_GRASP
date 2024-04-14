using Windows;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PopupFactory : IWindowFactory<PopupName, MonoWindow>
    {
        private PopupCatalog catalog;

        private Transform container;

        public void Construct(PopupCatalog catalog, Transform container)
        {
            this.catalog = catalog;
            this.container = container;
        }

        public MonoWindow CreateWindow(PopupName key)
        {
            var prefab = this.catalog.GetPrefab(key);
            var popup = GameObject.Instantiate(prefab, this.container);
            return popup;
        }
    }
}