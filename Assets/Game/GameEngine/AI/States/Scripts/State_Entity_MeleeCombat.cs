using System;
using AI.Blackboards;
using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class State_Entity_MeleeCombat : State
    {
        public string UnitKey
        {
            set { this.unitKey = value; }
        }

        public string TargetKey
        {
            set { this.targetKey = value; }
        }

        private IBlackboard blackboard;

        private Agent_Entity_MeleeCombat meleeAgent = new();
        
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        public void Construct(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public override void Enter()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                return;
            }

            this.meleeAgent.SetAttacker(unit);
            this.meleeAgent.SetTarget(target);
            this.meleeAgent.Play();
        }

        public override void Exit()
        {
            this.meleeAgent.Stop();
        }
    }
}