#if UNITY_PURCHASING
using UnityEngine.Purchasing;

namespace Purchasing
{
    public struct InitResult
    {
        public bool isSuccess;
        public InitializationFailureReason error;
    }
}
#endif