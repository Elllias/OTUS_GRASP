namespace Lessons.Architecture.Loading
{
    public sealed class PluginsStartable : IAppStartable
    {
        void IAppStartable.Start()
        {
            AppsFlyer.startSDK();
            FB.Init(null, null);
        }
    }
}