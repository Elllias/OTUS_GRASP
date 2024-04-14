using System;
using Elementary;

namespace Game.GameEngine.Animation
{
    public sealed class AnimatorState_ListenEvent : State
    {
        private AnimatorMachine animationSystem;

        private IAction action;

        private string[] animationEvents;

        public void ConstructAnimMachine(AnimatorMachine machine)
        {
            this.animationSystem = machine;
        }

        public void ConstructAnimEvents(params string[] animEvents)
        {
            this.animationEvents = animEvents;
        }

        public void ConstructAction(IAction action)
        {
            this.action = action;
        }

        public void ConstructAction(Action action)
        {
            this.action = new ActionDelegate(action);
        }

        public override void Enter()
        {
            this.animationSystem.OnStringReceived += this.OnAnimationEvent;
        }

        public override void Exit()
        {
            this.animationSystem.OnStringReceived -= this.OnAnimationEvent;
        }

        private void OnAnimationEvent(string message)
        {
            if (this.ContainsEvent(message))
            {
                this.action.Do();
            }
        }

        private bool ContainsEvent(string message)
        {
            for (int i = 0, count = this.animationEvents.Length; i < count; i++)
            {
                if (this.animationEvents[i] == message)
                {
                    return true;
                }
            }

            return false;
        }
    }
}