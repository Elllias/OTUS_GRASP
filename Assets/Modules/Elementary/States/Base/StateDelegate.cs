using System;

namespace Elementary
{
    public sealed class StateDelegate : State
    {
        private Action<bool> onEnter;

        public StateDelegate()
        {
        }

        public StateDelegate(Action<bool> onEnter)
        {
            this.onEnter = onEnter;
        }

        public void Construct(Action<bool> onEnter)
        {
            this.onEnter = onEnter;
        }

        public override void Enter()
        {
            this.onEnter.Invoke(true);
        }

        public override void Exit()
        {
            this.onEnter.Invoke(false);
        }
    }
}