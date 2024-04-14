namespace Lessons.AI.HierarchicalStateMachine
{
    public class AIStateMachine : AIState
    {
        private AIState currentState;

        public override void OnEnter()
        {
            if (this.currentState != null)
            {
                this.currentState.OnEnter();
            }
        }

        public override void OnUpdate()
        {
            if (this.currentState != null)
            {
                this.currentState.OnUpdate();
            }
        }

        public override void OnExit()
        {
            if (this.currentState != null)
            {
                this.currentState.OnExit();
            }
        }

        public void SwitchState(AIState state)
        {
            if (this.currentState == state)
            {
                return;
            }

            if (this.currentState != null)
            {
                this.currentState.OnExit();
            }

            this.currentState = state;
            this.currentState.OnEnter();
        }
    }
}