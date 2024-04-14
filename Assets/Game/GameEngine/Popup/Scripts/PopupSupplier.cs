using System.Collections.Generic;
using GameSystem;
using Windows;

namespace Game.GameEngine
{
    public sealed class PopupSupplier : IWindowSupplier<PopupName, MonoWindow>
    {
        private readonly Dictionary<PopupName, MonoWindow> cashedFrames = new();
        
        private GameContext gameContext;

        private IWindowFactory<PopupName, MonoWindow> factory;

        public void Construct(GameContext gameContext, IWindowFactory<PopupName, MonoWindow> factory)
        {
            this.gameContext = gameContext;
            this.factory = factory;
        }

        public MonoWindow LoadWindow(PopupName key)
        {
            if (this.cashedFrames.TryGetValue(key, out var popup))
            {
                popup.gameObject.SetActive(true);
            }
            else
            {
                popup = this.factory.CreateWindow(key);
                this.cashedFrames.Add(key, popup);
            }
            
            if (popup.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.RegisterElement(gameElement);
            }

            popup.transform.SetAsLastSibling();
            return popup;
        }

        public void UnloadWindow(MonoWindow window)
        {
            if (window.TryGetComponent(out IGameElement gameElement))
            {
                this.gameContext.UnregisterElement(gameElement);
            }

            window.gameObject.SetActive(false);
        }
    }
}