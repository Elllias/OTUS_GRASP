using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Component «Is Visible In Screen»")]
    public sealed class UComponent_IsVisibleInScreen : MonoBehaviour
    {
        public bool IsVisible
        {
            get { return this.visibleScript.IsVisible; }
        }

        [SerializeField]
        private BecameVisibleScript visibleScript;
    }
}