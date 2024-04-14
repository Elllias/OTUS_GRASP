using System;
using AI.Blackboards;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class Command_AttackTarget : Command_BTNode<CommandArgs_AttackTarget>
    {
        public string TargetKey
        {
            set { this.targetKey = value; }
        }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private IBlackboard blackboard;

        public void Construct(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        protected override void Execute(CommandArgs_AttackTarget args)
        {
            this.blackboard.ReplaceVariable(this.targetKey, args.target);
            base.Execute(args);
        }

        protected override void OnInterrupt()
        {
            this.blackboard.RemoveVariable(this.targetKey);
            base.OnInterrupt();
        }
    }
}