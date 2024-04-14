using System;
using AI.Blackboards;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class Command_MoveToPosition : Command_BTNode<CommandArgs_MoveToPosition>
    {
        public string MovePosiitonKey
        {
            set { this.movePositionKey = value; }
        }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string movePositionKey;

        private IBlackboard blackboard;

        public void Construct(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        protected override void Execute(CommandArgs_MoveToPosition args)
        {
            this.blackboard.ReplaceVariable(this.movePositionKey, args.targetPosition);
            base.Execute(args);
        }

        protected override void OnInterrupt()
        {
            this.blackboard.RemoveVariable(this.movePositionKey);
            base.OnInterrupt();
        }
    }
}