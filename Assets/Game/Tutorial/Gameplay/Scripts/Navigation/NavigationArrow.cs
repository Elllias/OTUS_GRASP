using UnityEngine;

namespace Game.Tutorial.Gameplay
{
    public sealed class NavigationArrow : MonoBehaviour
    {
        [SerializeField]
        private GameObject rootGameObject;

        [SerializeField]
        private Transform rootTransform;

        public void Show()
        {
            this.rootGameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);   
        }

        public void SetPosition(Vector3 position)
        {
            this.rootTransform.position = position;
        }
        
        public void LookAt(Vector3 targetPosition)
        {
            var distanceVector = targetPosition - this.rootTransform.position;
            distanceVector.y = 0;
            this.rootTransform.rotation = Quaternion.LookRotation(distanceVector.normalized, Vector3.up);
        }
    }
}