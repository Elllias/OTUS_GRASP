using System;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class AnimatorSystem : MonoBehaviour
    {
        private static readonly int State = Animator.StringToHash("State");

        public event Action<string> OnEventReceived
        {
            add { this.eventDispatcher.OnEventReceived += value; }
            remove { this.eventDispatcher.OnEventReceived -= value; }
        }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AnimatorEventDispatcher eventDispatcher;

        [SerializeField]
        private AnimatorStateMachine stateMachine;

        public void SwitchState(AnimatorStateType stateType)
        {
            this.animator.SetInteger(State, (int) stateType);
            this.stateMachine.SwitchState(stateType);
        }
    }
}