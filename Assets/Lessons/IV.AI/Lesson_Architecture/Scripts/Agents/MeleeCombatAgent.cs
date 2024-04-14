using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class MeleeCombatAgent : Agent
    {
        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private IEntity target;

        private IComponent_MeleeCombat combatComponent;

        private Coroutine combatCoroutine;

        [Button]
        public void SetUnit(IEntity unit)
        {
            if (this.unit != null)
            {
                this.combatComponent.StopCombat();
            }
        
            this.unit = unit;
            this.combatComponent = unit?.Get<IComponent_MeleeCombat>();
        }

        [Button]
        public void SetTarget(IEntity target)
        {
            if (this.unit != null)
            {
                this.combatComponent.StopCombat();
            }
        
            this.target = target;
        }

        protected override void OnStart()
        {
            this.combatCoroutine = this.StartCoroutine(this.CombatRoutine());
        }

        protected override void OnStop()
        {
            if (this.combatCoroutine != null)
            {
                this.StopCoroutine(this.combatCoroutine);
                this.combatCoroutine = null;
            }

            if (this.combatComponent.IsCombat)
            {
                this.combatComponent.StopCombat();
            }
        }

        private IEnumerator CombatRoutine()
        {
            var period = new WaitForFixedUpdate();

            while (true)
            {
                if (this.unit != null && this.target != null)
                {
                    this.StartCombat();
                }

                yield return period;
            }
        }

        private void StartCombat()
        {
            if (!this.combatComponent.IsCombat)
            {
                this.combatComponent.StartCombat(new CombatOperation(this.target));
            }
        }
    }
}