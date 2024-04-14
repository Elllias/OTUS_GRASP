using UnityEngine;
using UnityEngine.Events;

namespace Elementary
{
    [AddComponentMenu("Elementary/States/State «Invoke Unity Events»")]
    public sealed class MonoState_InvokeUnityEvents : MonoState
    {
        [SerializeField]
        private UnityEvent enterEvent;

        [SerializeField]
        private UnityEvent exitEvent;

        public override void Enter()
        {
            this.enterEvent.Invoke();
        }

        public override void Exit()
        {
            this.exitEvent.Invoke();
        }
    }
}