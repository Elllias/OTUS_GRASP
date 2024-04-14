using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatAction_DealDamageIfAlive : IAction<CombatOperation>
    {
        public object attacker;

        public IValue<int> damage;

        public CombatAction_DealDamageIfAlive()
        {
        }

        public CombatAction_DealDamageIfAlive(object attacker, IValue<int> damage)
        {
            this.attacker = attacker;
            this.damage = damage;
        }
        
        public void Do(CombatOperation operation)
        {
            var target = operation.targetEntity;
            var aliveComponent = target.Get<IComponent_IsAlive>();
            if (!aliveComponent.IsAlive)
            {
                return;
            }

            var takeDamageComponent = target.Get<IComponent_TakeDamage>();
            var damageEvent = new TakeDamageArgs(
                this.damage.Current,
                TakeDamageReason.MELEE,
                this.attacker
            );
            takeDamageComponent.TakeDamage(damageEvent);
        }
    }
}