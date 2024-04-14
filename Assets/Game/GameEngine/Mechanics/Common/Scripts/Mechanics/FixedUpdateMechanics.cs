using System;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class FixedUpdateMechanics : IFixedUpdateListener
    {
        private Action<float> action;

        public void Construct(Action<float> action)
        {
            this.action = action;
        }

        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            this.action.Invoke(deltaTime);
        }
    }
}