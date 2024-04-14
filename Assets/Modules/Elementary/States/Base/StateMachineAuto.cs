using System.Collections.Generic;

namespace Elementary
{
    public class StateMachineAuto<T> : StateMachine<T>
    {
        public List<StateTransition<T>> orderedTransitions;

        public void Update()
        {
            this.UpdateTransitions();
        }

        private void UpdateTransitions()
        {
            for (int i = 0, count = this.orderedTransitions.Count; i < count; i++)
            {
                var transition = this.orderedTransitions[i];
                if (transition.condition.IsTrue())
                {
                    if (!transition.stateId.Equals(this.CurrentState))
                    {
                        this.SwitchState(transition.stateId);                        
                    }
                    return;
                }
            }
        }
    }
}