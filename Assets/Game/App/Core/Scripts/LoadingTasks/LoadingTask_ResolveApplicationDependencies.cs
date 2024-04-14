using System;
using Game.UI;
using JetBrains.Annotations;
using Services;

namespace Game.App
{
    [UsedImplicitly]
    public sealed class LoadingTask_ResolveApplicationDependencies : ILoadingTask
    {
        public async void Do(Action<LoadingResult> callback)
        {
            await ServiceInjector.ResolveDependenciesAsync();
            LoadingScreen.ReportProgress(0.1f);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}