using UnityEngine;

namespace Game.GameEngine.GUI
{
    [AddComponentMenu("GameEngine/GUI/GUI Canvas Service")]
    public sealed class GUICanvasService : MonoBehaviour
    {
        public Transform RootTransform
        {
            get { return this.rootTransform; }
        }

        public Canvas Canvas
        {
            get { return this.canvas; }
        }

        [Space]
        [SerializeField]
        private Transform rootTransform;

        [SerializeField]
        private Canvas canvas;
    }
}