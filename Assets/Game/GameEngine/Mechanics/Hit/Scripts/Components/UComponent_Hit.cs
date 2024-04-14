using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Component «Hit»")]
    public sealed class UComponent_Hit : MonoBehaviour, IComponent_Hit
    {
        [SerializeField]
        private MonoEmitter receiver;
        
        public void Hit()
        {
            this.receiver.Call();
        }
    }
}