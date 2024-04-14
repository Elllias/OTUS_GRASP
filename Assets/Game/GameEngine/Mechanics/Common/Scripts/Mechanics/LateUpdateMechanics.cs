using System;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class LateUpdateMechanics : ILateUpdateListener
    {
        private Action<float> action;

        public void Construct(Action<float> action)
        {
            this.action = action;
        }

        void ILateUpdateListener.LateUpdate(float deltaTime)
        {
            this.action.Invoke(deltaTime);
        }
    }
}