using System.Collections.Generic;

namespace Elementary
{
    public class StateComposite : State
    {
        protected List<IState> states;

        public StateComposite()
        {
            this.states = new List<IState>(1);
        }

        public StateComposite(params IState[] states)
        {
            this.states = new List<IState>(states);
        }
        
        public override void Enter()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var state = this.states[i];
                state.Enter();
            }
        }

        public override void Exit()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var state = this.states[i];
                state.Exit();
            }
        }
        
        public static StateComposite operator +(StateComposite stateComposite, IState state)
        {
            if (stateComposite == null)
            {
                stateComposite = new StateComposite();
            }

            stateComposite.states.Add(state);
            return stateComposite;
        }

        public static StateComposite operator +(StateComposite stateComposite, IEnumerable<IState> states)
        {
            if (stateComposite == null)
            {
                stateComposite = new StateComposite();
            }

            stateComposite.states.AddRange(states);
            return stateComposite;
        }

        public static StateComposite operator -(StateComposite stateComposite, IState state)
        {
            if (stateComposite == null)
            {
                return null;
            }
            
            stateComposite.states.Remove(state);
            return stateComposite;
        }
    }
}