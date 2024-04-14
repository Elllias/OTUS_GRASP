using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat Action «Deal Damage If Alive»")]
    public sealed class UCombatAction_DealDamageIfAlive : UCombatAction
    {
        [SerializeField]
        public Object attacker;

        [SerializeField]
        public IntAdapter damage;
        
        public override void Do(CombatOperation operation)
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