using UnityEngine;

namespace Bullets
{
    public class BulletsController : MonoBehaviour
    {
        [SerializeField] private Transform _poolTransform;
        [SerializeField] private Transform _worldTransform;

        public Transform GetPoolTransform()
        {
            return _poolTransform;
        }
        
        public Transform GetWorldTransform()
        {
            return _worldTransform;
        }
    }
}