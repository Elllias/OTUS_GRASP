#if UNITY_PURCHASING
using UnityEngine.Purchasing;

namespace Purchasing
{
    public interface ICompleteListener
    {
        void OnComplete(PurchaseEventArgs args);
    }
}
#endif