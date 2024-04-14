using UnityEngine;
using UnityEngine.Events;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Enable/Enable Observer «Invoke Unity Events»")]
    public sealed class UEnableObserver_InvokeUnityEvents : UEnableObserver
    {
        [Space]
        [SerializeField]
        public UnityEvent onEnable;

        [SerializeField]
        public UnityEvent onDisable;

        protected override void SetEnable(bool isEnable)
        {
            if (isEnable)
            {
                this.onEnable?.Invoke();
            }
            else
            {
                this.onDisable?.Invoke();
            }
        }
    }
}