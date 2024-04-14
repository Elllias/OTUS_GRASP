using System;
using Game.UI;
using Services;

namespace Game.App
{
    public sealed class LoadingTask_StartRealtimeClock : ILoadingTask
    {
        public async void Do(Action<LoadingResult> callback)
        {
            var sessionStarter = ServiceLocator.GetService<RealtimeClockStarter>();
            await sessionStarter.StartClockAsync();
            LoadingScreen.ReportProgress(0.95f);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}