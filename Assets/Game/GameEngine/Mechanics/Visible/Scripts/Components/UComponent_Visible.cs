using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Visible/Component «Visible»")]
    public sealed class UComponent_Visible : MonoBehaviour,
        IComponent_IsVisible,
        IComponent_SetVisible
    {
        public bool IsVisible
        {
            get { return this.isVisible.Current; }
        }

        [SerializeField]
        private BoolVariable isVisible;

        public void SetVisible(bool isVisible)
        {
            this.isVisible.Current = isVisible;
        }
    }
}