using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public abstract class StateFixedUpdate : State, IFixedUpdateListener
    {
        private bool enabled;

        public sealed override void Enter()
        {
            this.OnEnter();
            this.enabled = true;
        }

        public sealed override void Exit()
        {
            this.enabled = false;
            this.OnExit();
        }

        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            if (this.enabled)
            {
                this.FixedUpdate(deltaTime);
            }
        }

        protected abstract void FixedUpdate(float deltaTime);

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
        {
        }
    }
}