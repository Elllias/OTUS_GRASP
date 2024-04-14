using UnityEngine;

namespace Elementary
{
    public interface IColliderDetectionHandler
    {
        void OnCollidersUpdated(Collider[] buffer, int size);
    }
}