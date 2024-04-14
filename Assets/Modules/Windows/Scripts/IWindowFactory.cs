namespace Windows
{
    public interface IWindowFactory<in TKey, out TWindow> where TWindow : IWindow
    {
        TWindow CreateWindow(TKey key);
    }
}