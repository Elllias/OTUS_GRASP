using System;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_InstallApplicationManager : ILoadingTask
    {
        private readonly ApplicationManager manager;

        [ServiceInject]
        public LoadingTask_InstallApplicationManager(ApplicationManager manager)
        {
            this.manager = manager;
        }

        public void Do(Action<LoadingResult> callback)
        {
            var services = ServiceLocator.GetAllServices();
            foreach (var service in services)
            {
                if (service is IAppUpdateListener or IAppPauseListener or IAppResumeListener or IAppQuitListener)
                {
                    this.manager.AddListener(service);
                }
            }

            callback?.Invoke(LoadingResult.Success());
        }
    }
}