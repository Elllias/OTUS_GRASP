using System;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_LoadApplicationConfigs : ILoadingTask
    {
        private readonly IConfigLoader[] loaders;
    
        [ServiceInject]
        public LoadingTask_LoadApplicationConfigs(IConfigLoader[] loaders)
        {
            this.loaders = loaders;
        }
        
        public void Do(Action<LoadingResult> callback)
        {
            for (int i = 0, count = this.loaders.Length; i < count; i++)
            {
                var loader = this.loaders[i];
                loader.LoadConfigs();
            }

            callback?.Invoke(LoadingResult.Success());
        }
    }
}