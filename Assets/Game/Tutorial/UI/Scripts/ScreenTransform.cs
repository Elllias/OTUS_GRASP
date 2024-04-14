using UnityEngine;

namespace Game.Tutorial.UI
{
    public sealed class ScreenTransform : MonoBehaviour
    {
        public Transform Value
        {
            get { return this.rootTransform; }
        }

        [SerializeField]
        private Transform rootTransform;
    }
}