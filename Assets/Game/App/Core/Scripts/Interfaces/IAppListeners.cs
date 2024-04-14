namespace Game.App
{
    public interface IAppInitListener
    {
        void Init();
    }

    public interface IAppStartListener
    {
        void Start();
    }

    public interface IAppUpdateListener
    {
        void OnUpdate(float deltaTime);
    }

    public interface IAppPauseListener
    {
        void OnPaused();
    }

    public interface IAppResumeListener
    {
        void OnResumed();
    }

    public interface IAppQuitListener
    {
        void OnQuit();
    }
}