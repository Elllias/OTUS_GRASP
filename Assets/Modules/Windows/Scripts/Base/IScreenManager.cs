using System;

namespace Windows
{
    public interface IScreenManager<TKey>
    {
        event Action<TKey> OnScreenShown;

        event Action<TKey> OnScrenHidden; 

        event Action<TKey> OnScreenChanged;

        void ChangeScreen(TKey key, object args = default);

        bool IsScreenActive(TKey key);
    }
}