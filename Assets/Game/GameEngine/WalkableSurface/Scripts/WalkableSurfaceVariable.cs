using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class WalkableSurfaceVariable : MonoBehaviour
    {
        [ReadOnly]
        [ShowInInspector]
        public bool IsSurfaceExists
        {
            get { return this.surfaceExists; }
        }

        [ReadOnly]
        [ShowInInspector]
        public IWalkableSurface Surface
        {
            get { return this.surface; }
        }

        private IWalkableSurface surface;

        private bool surfaceExists;

        public void SetSurface(IWalkableSurface surface)
        {
            this.surface = surface;
            this.surfaceExists = true;
        }

        public void ResetSurface()
        {
            this.surface = null;
            this.surfaceExists = false;
        }
    }
}