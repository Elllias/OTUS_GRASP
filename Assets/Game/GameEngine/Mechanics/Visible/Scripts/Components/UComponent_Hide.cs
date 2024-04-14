using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Visible/Component «Hide»")]
    public sealed class UComponent_Hide : MonoBehaviour, IComponent_Hide
    {
        [SerializeField]
        private MonoEmitter receiver;

        public void Hide()
        {
            this.receiver.Call();
        }
    }
}