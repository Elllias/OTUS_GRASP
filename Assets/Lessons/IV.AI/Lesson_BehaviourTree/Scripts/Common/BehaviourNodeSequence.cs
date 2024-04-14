using UnityEngine;

namespace Lessons.AI.LessonBehaviourTree
{
    public sealed class BehaviourNodeSequence : BehaviourNode, IBehaviourCallback
    {
        [SerializeField]
        private BehaviourNode[] orderedNodes;
        
        private BehaviourNode currentNode;
        private int pointer;

        protected override void Run()
        {
            if (this.orderedNodes is not {Length: > 0})
            {
                this.Return(true);
                return;
            }

            this.pointer = 0;
            this.currentNode = this.orderedNodes[this.pointer];
            this.currentNode.Run(callback: this);
        }

        void IBehaviourCallback.Invoke(BehaviourNode node, bool success)
        {
            if (!success)
            {
                this.Return(false);
                return;
            }

            if (this.pointer + 1 >= this.orderedNodes.Length)
            {
                this.Return(true);
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