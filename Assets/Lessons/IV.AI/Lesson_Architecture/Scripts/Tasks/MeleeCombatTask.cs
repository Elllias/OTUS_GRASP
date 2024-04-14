using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class MeleeCombatTask : Task
    {
        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private IEntity target;

        private IComponent_MeleeCombat combatComponent;

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
            this.combatComponent = unit.Get<IComponent_MeleeCombat>();
        }

        [Button]
        public void SetTarget(IEntity target)
        {
            this.target = target;
        }

        protected override void Do()
        {
            this.combatComponent.OnCombatStopped += this.OnCombatFinished;
            this.combatComponent.StartCombat(new CombatOperation(this.target));
        }

        protected override void OnCancel()
        {
            this.combatComponent.OnCombatStopped -= this.OnCombatFinished;
            this.combatComponent.StopCombat();
        }

        private void OnCombatFinished(CombatOperation operation)
        {
            this.combatComponent.OnCombatStopped -= this.OnCombatFinished;

            var success = operation.targetDestroyed;
            Debug.Log($"IS COMBAT SUCCESSFUL {success}");
            this.Return(success);
        }
    }
}