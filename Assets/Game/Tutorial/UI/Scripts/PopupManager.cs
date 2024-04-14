using System;
using GameSystem;
using Windows;
using Game.GameEngine;
using UnityEngine;

namespace Game.Tutorial.UI
{
    public sealed class PopupManager : MonoBehaviour, IWindow.Callback, IGameConstructElement
    {
        private GameContext gameContext;

        private InputStateManager inputManager;

        [SerializeField]
        private Transform rootTransform;

        private MonoWindow currentPopup;

        private Action callback;

        public void Show(MonoWindow prefab, object args = null, Action callback = null)
        {
            if (this.currentPopup != null)
            {
                return;
            }

            this.callback = callback;
            this.currentPopup = Instantiate(prefab, this.rootTransform);

            if (this.currentPopup.TryGetComponent(out IGameElement element))
            {
                this.gameContext.RegisterElement(element);
            }

            this.inputManager.SwitchState(InputStateId.LOCK);
            this.currentPopup.Show(args, callback: this);
        }

        void IWindow.Callback.OnClose(IWindow popup)
        {
            this.currentPopup.Hide();
            this.inputManager.SwitchState(InputStateId.BASE);

            if (this.currentPopup.TryGetComponent(out IGameElement element))
            {
                this.gameContext.UnregisterElement(element);
            }
            
            Destroy(this.currentPopup.gameObject);
            this.currentPopup = null;
            this.callback?.Invoke();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.gameContext = context;
            this.inputManager = context.GetService<InputStateManager>();
        }
    }
}