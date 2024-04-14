using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Respawn/Component «Respawn»")]
    public sealed class UComponent_Respawn : MonoBehaviour, IComponent_Respawn
    {
        [SerializeField]
        private MonoEmitter eventReceiver;
        
        public void Respawn()
        {
            this.eventReceiver.Call();
        }
    }
}