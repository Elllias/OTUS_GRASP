using UnityEngine;

namespace Lessons.AI.LessonBehaviourTree
{
    public sealed class BehaviourNodeSelector : BehaviourNode, IBehaviourCallback
    {
        [SerializeField]
        private BehaviourNode[] orderedNodes;
        
        private BehaviourNode currentNode;
        private int pointer;

        protected override void Run()
        {
            if (this.orderedNodes == null && this.orderedNodes.Length <= 0)
            {
                this.Return(false);
                return;
            }

            this.pointer = 0;
            this.currentNode = orderedNodes[this.pointer];
            this.currentNode.Run(callback: this);
        }

        void IBehaviourCallback.Invoke(BehaviourNode node, bool success)
        {
            if (success)
            {
                this.Return(true);
                return;
            }

            if (this.pointer + 1 >= this.orderedNodes.Length)
            {
                this.Return(false);
                return;
            }

            this.pointer++;
            this.currentNode = this.orderedNodes[this.pointer];
            this.currentNode.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.currentNode != null && this.currentNode.IsRunning)
            {
                this.currentNode.Abort();
            }
        }
    }
}