using AI.Agents;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class Agent_Entity_MeleeCombat : AgentCoroutine
    {
        private IEntity attacker;

        private IEntity target;

        private IComponent_MeleeCombat combatComponent;

        private Coroutine combatCoroutine;

        public Agent_Entity_MeleeCombat()
        {
            this.SetFramePeriod(new WaitForFixedUpdate());
        }

        public void SetAttacker(IEntity unit)
        {
            if (this.attacker != null)
            {
                this.combatComponent.StopCombat();
            }

            this.attacker = unit;
            this.combatComponent = unit?.Get<IComponent_MeleeCombat>();
        }

        public void SetTarget(IEntity target)
        {
            if (this.attacker != null)
            {
                this.combatComponent.StopCombat();
            }

            this.target = target;
        }

        protected override void OnStop()
        {
            base.OnStop();

            if (this.combatComponent.IsCombat)
            {
                this.combatComponent.StopCombat();
            }
        }

        protected override void Update()
        {
            if (this.attacker != null && this.target != null)
            {
                this.StartCombat();
            }
        }

        private void StartCombat()
        {
            if (this.combatComponent.IsCombat)
            {
                return;
            }

            var combatOperation = new CombatOperation(this.target);
            this.combatComponent.StartCombat(combatOperation);
        }
    }
}