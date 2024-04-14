using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Deal Melee Damage»")]
    public sealed class UAction_DealMeleeDamage : MonoAction
    {
        [SerializeField]
        public UCombatOperator combatOperator;

        [SerializeField]
        public Object attacker;

        [SerializeField]
        public IntAdapter damage;

        [Title("Methods")]
        [Button]
        [GUIColor(0, 1, 0)]
        public override void Do()
        {
            if (!this.combatOperator.IsActive)
            {
                return;
            }
        
            var target = this.combatOperator.Current.targetEntity;
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