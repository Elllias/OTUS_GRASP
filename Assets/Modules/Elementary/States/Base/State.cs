using System;

namespace Elementary
{
    [Serializable]
    public class State : IState
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}