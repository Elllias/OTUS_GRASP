using System;
using UnityEngine;
using UnityEngine.Events;

namespace Windows
{
    [AddComponentMenu(Extensions.MENU_PATH + "Window")]
    public class MonoWindow : MonoBehaviour, IWindow
    {
        [Space]
        [SerializeField]
        private UnityEvent<object> onShow;

        [SerializeField]
        private UnityEvent onHide;

        private IWindow.Callback callback;

        public void Show(object args)
        {
            this.OnShow(args);
            this.onShow?.Invoke(args);
        }

        public void Show(object args, IWindow.Callback callback)
        {
            this.callback = callback;
            this.OnShow(args);
            this.onShow?.Invoke(args);
        }

        public void Hide()
        {
            this.OnHide();
            this.onHide?.Invoke();
        }

        public void NotifyAboutClose()
        {
            if (this.callback != null)
            {
                this.callback.OnClose(this);
            }
        }

        protected virtual void OnShow(object args)
        {
        }

        protected virtual void OnHide()
        {
        }
    }

    public abstract class MonoWindow<TArgs> : MonoWindow
    {
        protected sealed override void OnShow(object args)
        {
            if (args is TArgs tArgs)
            {
                this.OnShow(tArgs);
            }
            else
            {
                throw new Exception($"Expected args of type {typeof(TArgs).Name}!");
            }
        }

        protected abstract void OnShow(TArgs args);
    }
}