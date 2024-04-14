#if UNITY_PURCHASING

using System;
using Purchasing;
using Services;

namespace Game.App
{
    public static class PurchasingInitializer
    {
        private static readonly ICompleteListener[] completeListeners =
        {
            new PurchaseAnalyticsListener()
        };

        private static readonly IFailListener[] failListeners =
        {
        };

        public static void Init(Action<InitResult> callback)
        {
            var purchaseManager = ServiceLocator.GetService<PurchaseManager>();
            purchaseManager.AddCompleteListeners(completeListeners);
            purchaseManager.AddFailListeners(failListeners);
            purchaseManager.Initialize(callback);
        }
    }
}

#endif