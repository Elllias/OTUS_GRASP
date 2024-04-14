using UnityEngine;

namespace Game.GameEngine.GUI
{
    public sealed class GUIParticleViewportService : MonoBehaviour
    {
        public Transform WorldViewport
        {
            get { return this.worldViewport; }
        }

        public Transform OverlayViewport
        {
            get { return this.overlayViewport; }
        }

        [SerializeField]
        private Transform worldViewport;

        [SerializeField]
        private Transform overlayViewport;
    }
}