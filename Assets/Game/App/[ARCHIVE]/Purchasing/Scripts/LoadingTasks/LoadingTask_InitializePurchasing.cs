using System;

namespace Game.App.Loading
{
    public sealed class LoadingTask_InitializePurchasing : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
#if UNITY_PURCHASING
            PurchasingInitializer.Init(result =>
            {
                if (result.isSuccess)
                {
                    callback?.Invoke(LoadingResult.Success());
                }
                else
                {
                    callback?.Invoke(LoadingResult.Fail(result.error.ToString()));
                }
            });
#else
            callback?.Invoke(LoadingResult.Success());
#endif
        }
    }
}