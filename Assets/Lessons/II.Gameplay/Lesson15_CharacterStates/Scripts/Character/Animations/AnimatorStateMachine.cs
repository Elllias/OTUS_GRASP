using System;
using Lessons.StateMachines;
using UnityEngine;

namespace Lessons.Character.Animations
{
    
    [Serializable]
    public sealed class AnimatorStateMachine<T> : TransitionableStateMachine<T> where T : Enum
    {
        private static readonly int State = Animator.StringToHash("State");

        public event Action<string> OnMessageReceived
        {
            add { this.dispatcher.OnMessageReceived += value; }
            remove { this.dispatcher.OnMessageReceived -= value; }
        }

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AnimatorDispatcher dispatcher;

        public override void SwitchState(T stateType)
        {
            base.SwitchState(stateType);
            this.animator.SetInteger(State, Convert.ToInt32(stateType));
        }
    }
}