using System;
using Sirenix.OdinInspector;

namespace Windows
{
    public sealed class ScreenManager<TKey, TScreen> : IScreenManager<TKey> where TScreen : IWindow
    {
        public event Action<TKey> OnScreenShown;

        public event Action<TKey> OnScrenHidden;

        public event Action<TKey> OnScreenChanged;

        private IWindowSupplier<TKey, TScreen> supplier;

        private TKey currentScreenKey;

        private TScreen currentScreen;

        public ScreenManager(IWindowSupplier<TKey, TScreen> supplier = null)
        {
            this.supplier = supplier;
        }

        public bool IsScreenActive(TKey key)
        {
            return ReferenceEquals(this.currentScreenKey, key);
        }

        [Button]
        public void ChangeScreen(TKey key, object args = default)
        {
            if (!ReferenceEquals(this.currentScreen, null))
            {
                this.HideScreenInternal(this.currentScreenKey, this.currentScreen);
            }

            this.currentScreenKey = key;
            this.ShowScreenInternal(key, args);
            this.OnScreenChanged?.Invoke(key);
        }
        
        private void ShowScreenInternal(TKey key, object args)
        {
            this.currentScreen = this.supplier.LoadWindow(key);
            this.currentScreen.Show(args);
            this.OnScreenShown?.Invoke(key);
        }

        private void HideScreenInternal(TKey key, TScreen screen)
        {
            screen.Hide();
            this.supplier.UnloadWindow(screen);
            this.OnScrenHidden?.Invoke(key);
        }
        
        public void SetSupplier(IWindowSupplier<TKey, TScreen> supplier)
        {
            this.supplier = supplier;
        }
    }
}