using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_GetPivot : IComponent_GetPivot
    {
        public Transform Pivot
        {
            get { return this.pivot; }
        }

        private readonly Transform pivot;

        public Component_GetPivot(Transform pivot)
        {
            this.pivot = pivot;
        }
    }
}