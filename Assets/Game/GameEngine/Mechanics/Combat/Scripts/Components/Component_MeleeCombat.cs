using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_MeleeCombat : IComponent_MeleeCombat 
    {
        public event Action<CombatOperation> OnCombatStarted
        {
            add { this.@operator.OnStarted += value; }
            remove { this.@operator.OnStarted -= value; }
        }

        public event Action<CombatOperation> OnCombatStopped
        {
            add { this.@operator.OnStopped += value; }
            remove { this.@operator.OnStopped -= value; }
        }

        public bool IsCombat
        {
            get { return this.@operator.IsActive; }
        }

        private readonly IOperator<CombatOperation> @operator;

        public Component_MeleeCombat(IOperator<CombatOperation> @operator)
        {
            this.@operator = @operator;
        }

        public bool CanStartCombat(CombatOperation operation)
        {
            return this.@operator.CanStart(operation);
        }

        public void StartCombat(CombatOperation operation)
        {
            this.@operator.DoStart(operation);
        }

        public void StopCombat()
        {
            this.@operator.Stop();
        }
    }
}