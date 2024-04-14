#if UNITY_PURCHASING

using Purchasing;
using UnityEngine.Purchasing;

namespace Game.App
{
    public sealed class PurchaseAnalyticsListener : ICompleteListener
    {
        void ICompleteListener.OnComplete(PurchaseEventArgs args)
        {
            // PurchaseAnalytics.LogReceipt(args.purchasedProduct);
        }
    }
}

#endif