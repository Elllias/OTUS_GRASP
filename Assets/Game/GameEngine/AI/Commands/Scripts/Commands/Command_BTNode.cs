using AI.BTree;
using AI.Commands;

namespace Game.GameEngine.AI
{
    public class Command_BTNode<T> : AICommand<T>, IBehaviourCallback
    {
        public IBehaviourNode BehaviourNode
        {
            set { this.behaviourNode = value; }
        }

        private IBehaviourNode behaviourNode;

        public Command_BTNode()
        {
        }

        public Command_BTNode(IBehaviourNode node)
        {
            this.behaviourNode = node;
        }

        protected override void Execute(T args)
        {
            this.behaviourNode.Run(callback: this);
        }

        protected override void OnInterrupt()
        {
            this.behaviourNode.Abort();
        }

        void IBehaviourCallback.Invoke(IBehaviourNode node, bool success)
        {
            this.Return(success);
        }
    }
}