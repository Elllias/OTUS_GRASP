using System;
using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTNode_Entity_MeleeCombat : BehaviourNode
    {
        private IBlackboard blackboard;

        private string attackerKey;

        private string targetKey;

        private IComponent_MeleeCombat unitComponent;

        public void ConstructBlackboard(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void ConstructBlackboardKeys(string attackerKey, string targetKey)
        {
            this.attackerKey = attackerKey;
            this.targetKey = targetKey;
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.attackerKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            this.unitComponent = unit.Get<IComponent_MeleeCombat>();
            this.TryStartCombat(target);
        }

        private void TryStartCombat(IEntity target)
        {
            var operation = new CombatOperation(target);
            if (this.unitComponent.CanStartCombat(operation))
            {
                this.unitComponent.OnCombatStopped += this.OnCombatFinished;
                this.unitComponent.StartCombat(operation);
            }
            else
            {
                this.Return(false);
            }
        }

        private void OnCombatFinished(CombatOperation operation)
        {
            if (this.unitComponent != null)
            {
                this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
                this.unitComponent = null;
            }

            var success = operation.targetDestroyed;
            this.Return(success);
        }

        protected override void OnAbort()
        {
            if (this.unitComponent != null)
            {
                this.unitComponent.OnCombatStopped -= this.OnCombatFinished;
                this.unitComponent.StopCombat();
                this.unitComponent = null;
            }
        }
    }
}