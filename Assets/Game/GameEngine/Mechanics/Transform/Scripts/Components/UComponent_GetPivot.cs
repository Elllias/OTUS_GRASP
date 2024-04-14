using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Transform/Component «Get Pivot»")]
    public sealed class UComponent_GetPivot : MonoBehaviour, IComponent_GetPivot
    {
        public Transform Pivot
        {
            get { return this.pivot; }
        }

        [SerializeField]
        private Transform pivot;
    }
}