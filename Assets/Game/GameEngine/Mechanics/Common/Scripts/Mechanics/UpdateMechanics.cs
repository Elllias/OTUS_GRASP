using System;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class UpdateMechanics : IUpdateListener
    {
        private Action<float> action;

        public void Construct(Action<float> action)
        {
            this.action = action;
        }

        void IUpdateListener.Update(float deltaTime)
        {
            this.action.Invoke(deltaTime);
        }
    }
}