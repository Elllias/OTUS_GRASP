using System;
using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public sealed class BoolMechanics :
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private IVariable<bool> variable;

        private Action<bool> action;

        public void Construct(IVariable<bool> variable, Action<bool> action)
        {
            this.variable = variable;
            this.action = action;
        }

        void IAwakeListener.Awake()
        {
            this.action(this.variable.Current);
        }

        void IEnableListener.OnEnable()
        {
            this.variable.OnValueChanged += this.action;
        }

        void IDisableListener.OnDisable()
        {
            this.variable.OnValueChanged -= this.action;
        }
    }
}