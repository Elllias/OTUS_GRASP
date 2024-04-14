#if UNITY_PURCHASING
using UnityEngine.Purchasing;

namespace Purchasing
{
    public interface IFailListener
    {
        void OnFailed(Product product, PurchaseFailureReason failureReason);
    }
}
#endif