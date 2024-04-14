using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class MeleeCombatActor : Actor, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private int cost;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private IComponent_MeleeCombat combatComponent;

        public override int EvaluateCost()
        {
            return this.cost;
        }

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.targetKey);
        }

        protected override void Play()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }
            
            this.combatComponent = unit.Get<IComponent_MeleeCombat>();
            this.TryStartCombat(target);
        }
        
        private void TryStartCombat(IEntity target)
        {
            var operation = new CombatOperation(target);
            if (this.combatComponent.CanStartCombat(operation))
            {
                this.combatComponent.OnCombatStopped += this.OnCombatFinished;
                this.combatComponent.StartCombat(operation);
            }
            else
            {
                this.Return(false);
            }
        }

        private void OnCombatFinished(CombatOperation operation)
        {
            if (this.combatComponent != null)
            {
                this.combatComponent.OnCombatStopped -= this.OnCombatFinished;
                this.combatComponent = null;
            }

            this.Return(operation.targetDestroyed);
        }

        protected override void OnCancel()
        {
            if (this.combatComponent != null)
            {
                this.combatComponent.OnCombatStopped -= this.OnCombatFinished;
                this.combatComponent.StopCombat();
                this.combatComponent = null;
            }
        }
    }
}