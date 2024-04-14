using System.Collections.Generic;
using Declarative;

namespace Lessons.StateMachines
{
    public class TransitionableStateMachine<T> : StateMachine<T>, IUpdateListener
    {
        public delegate bool Predicate();

        private List<(T, Predicate)> transitions = new();
    
        public void AddTransition(T key, Predicate predicate)
        {
            this.transitions.Add(new(key, predicate));
        }

        void IUpdateListener.Update(float deltaTime)
        {
            foreach (var (stateType, condition) in this.transitions)
            {
                if (!stateType.Equals(this.currentStateType) && condition.Invoke())
                {
                    this.SwitchState(stateType);
                }
            }
        }
    }
}