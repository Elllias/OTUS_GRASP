using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Collect/Component «Collect» (Emitter)")]
    public sealed class UComponent_Collect_Emitter : MonoBehaviour, IComponent_Collect
    {
        [Space]
        [SerializeField]
        private MonoEmitter collectReceiver;
        
        [Button]
        [GUIColor(0, 1, 0)]
        public void Collect()
        {
            this.collectReceiver.Call();
        }
    }
}