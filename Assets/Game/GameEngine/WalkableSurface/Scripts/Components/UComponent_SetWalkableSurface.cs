using UnityEngine;

namespace Game.GameEngine
{
    public sealed class UComponent_SetWalkableSurface : MonoBehaviour, IComponent_SetWalkableSurface
    {
        [SerializeField]
        private WalkableSurfaceVariable surfaceHolder;
    
        public void SetSurface(IWalkableSurface surface)
        {
            this.surfaceHolder.SetSurface(surface);
        }
    }
}