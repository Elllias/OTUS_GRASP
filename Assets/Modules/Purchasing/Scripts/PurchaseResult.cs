#if UNITY_PURCHASING
using UnityEngine.Purchasing;

namespace Purchasing
{
    public struct PurchaseResult
    {
        public bool isSuccess;
        public PurchaseFailureReason error;
    }
}
#endif