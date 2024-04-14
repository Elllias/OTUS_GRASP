using Elementary;
using UnityEngine;
using UnityEngine.Events;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class AnimationState_InvokeUnityEvent : MonoState
    {
        [SerializeField]
        private AnimatorSystem animatorSystem;

        [SerializeField]
        private string animationEventId;
        
        [Space]
        [SerializeField]
        private UnityEvent unityEvent;

        public override void Enter()
        {
            this.animatorSystem.OnEventReceived += this.OnEvent;
        }

        public override void Exit()
        {
            this.animatorSystem.OnEventReceived -= this.OnEvent;
        }

        private void OnEvent(string eventId)
        {
            if (eventId == this.animationEventId)
            {
                this.unityEvent.Invoke();
            }
        }
    }
}