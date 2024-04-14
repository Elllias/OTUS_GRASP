namespace Windows
{
    public interface IWindowSupplier<in TKey, TWindow> where TWindow : IWindow
    {
        TWindow LoadWindow(TKey key);

        void UnloadWindow(TWindow window);
    }
}