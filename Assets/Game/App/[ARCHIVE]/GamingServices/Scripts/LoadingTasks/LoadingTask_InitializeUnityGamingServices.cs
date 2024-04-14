using System;
using System.Threading.Tasks;
using Services;

namespace Game.App.Loading
{
    public sealed class LoadingTask_InitializeUnityGamingServices : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var initializer = ServiceLocator.GetService<UnityGamingServiceIntializer>();
            
            initializer.Initialize(
                () => callback?.Invoke(LoadingResult.Success()),
                () => callback?.Invoke(LoadingResult.Fail("Failed Unity Gaming Service Initialization"))
            );
        }
    }
}