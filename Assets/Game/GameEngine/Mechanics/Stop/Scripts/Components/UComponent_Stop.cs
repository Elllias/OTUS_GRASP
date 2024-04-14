using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Stop/Component «Stop»")]
    public sealed class UComponent_Stop : MonoBehaviour, IComponent_Stop
    {
        [SerializeField]
        private MonoEmitter stopEmitter;
    
        public void Stop()
        {
            this.stopEmitter.Call();
        }
    }
}