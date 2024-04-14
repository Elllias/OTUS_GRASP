using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Visible/Component «Show»")]
    public sealed class UComponent_Show : MonoBehaviour, IComponent_Show
    {
        [SerializeField]
        private MonoEmitter receiver;
    
        public void Show()
        {
            this.receiver.Call();
        }
    }
}