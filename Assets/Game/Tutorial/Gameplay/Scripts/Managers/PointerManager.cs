using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public sealed class PointerManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject pointer;

        private void Awake()
        {
            this.pointer.SetActive(false);
        }

        [Button]
        public void ShowPointer(Transform targetPoint)
        {
            this.ShowPointer(targetPoint.position, targetPoint.rotation);
        }

        public void ShowPointer(Vector3 position, Quaternion rotation)
        {
            var pointerTransform = this.pointer.transform;
            pointerTransform.position = position;
            pointerTransform.rotation = rotation;
            
            this.pointer.SetActive(true);
        }

        public void HidePointer()
        {
            this.pointer.SetActive(false);
        }
    }
}