using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public abstract class StateUpdate : State, IUpdateListener
    {
        private bool enabled;

        public override void Enter()
        {
            this.enabled = true;
        }

        public override void Exit()
        {
            this.enabled = false;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            if (this.enabled)
            {
                this.Update(deltaTime);
            }
        }

        protected abstract void Update(float deltaTime);
    }
}