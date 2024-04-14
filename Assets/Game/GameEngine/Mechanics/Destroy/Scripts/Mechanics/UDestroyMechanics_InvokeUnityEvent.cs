using UnityEngine;
using UnityEngine.Events;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Destroy Mechanics «Invoke Unity Event»")]
    public sealed class UDestroyMechanics_InvokeUnityEvent : UDestroyMechanics
    {
        [SerializeField]
        public UnityEvent<DestroyArgs> unityEvent;

        protected override void OnDestroyEvent(DestroyArgs destroyArgs)
        {
            this.unityEvent.Invoke(destroyArgs);
        }
    }
}