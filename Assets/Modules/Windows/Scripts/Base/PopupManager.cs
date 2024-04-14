using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Windows
{
    public class PopupManager<TKey, TPopup> : IPopupManager<TKey>, IWindow.Callback where TPopup : IWindow
    {
        public event Action<TKey> OnPopupShown;

        public event Action<TKey> OnPopupHidden;

        public bool HasActivePopups
        {
            get { return this.activePopups.Count > 0; }
        }

        private IWindowSupplier<TKey, TPopup> supplier;

        private readonly Dictionary<TKey, TPopup> activePopups;

        private readonly List<TKey> cache;

        public PopupManager(IWindowSupplier<TKey, TPopup> supplier = null)
        {
            this.supplier = supplier;
            this.activePopups = new Dictionary<TKey, TPopup>();
            this.cache = new List<TKey>();
        }

        [Button]
        public void ShowPopup(TKey key, object args = default)
        {
            if (!this.IsPopupActive(key))
            {
                this.ShowPopupInternal(key, args);
            }
        }

        [Button]
        public void HidePopup(TKey key)
        {
            if (this.IsPopupActive(key))
            {
                this.HidePopupInternal(key);
            }
        }

        [Button]
        public void HideAllPopups()
        {
            this.cache.Clear();
            this.cache.AddRange(this.activePopups.Keys);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var popupName = this.cache[i];
                this.HidePopupInternal(popupName);
            }
        }

        public bool IsPopupActive(TKey key)
        {
            return this.activePopups.ContainsKey(key);
        }

        void IWindow.Callback.OnClose(IWindow window)
        {
            var popup = (TPopup) window;
            if (this.TryFindName(popup, out var popupName))
            {
                this.HidePopup(popupName);
            }
        }

        private void ShowPopupInternal(TKey name, object args)
        {
            var popup = this.supplier.LoadWindow(name);
            popup.Show(args, callback: this);

            this.activePopups.Add(name, popup);
            this.OnPopupShown?.Invoke(name);
        }

        private void HidePopupInternal(TKey name)
        {
            var popup = this.activePopups[name];
            popup.Hide();

            this.activePopups.Remove(name);
            this.supplier.UnloadWindow(popup);
            this.OnPopupHidden?.Invoke(name);
        }

        private bool TryFindName(TPopup popup, out TKey name)
        {
            foreach (var (key, otherPopup) in this.activePopups)
            {
                if (ReferenceEquals(popup, otherPopup))
                {
                    name = key;
                    return true;
                }
            }

            name = default;
            return false;
        }

        public void SetSupplier(IWindowSupplier<TKey, TPopup> supplier)
        {
            this.supplier = supplier;
        }
    }
}