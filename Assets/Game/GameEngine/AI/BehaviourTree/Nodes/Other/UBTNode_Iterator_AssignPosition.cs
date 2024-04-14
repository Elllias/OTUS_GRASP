using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Assign Position» (From Iterator)")]
    public sealed class UBTNode_Iterator_AssignPosition : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string iteratorKey;

        [BlackboardKey]
        [SerializeField]
        private string resultPositionKey;

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.iteratorKey, out IEnumerator<Vector3> iterator))
            {
                this.Return(false);
                return;
            }

            this.Blackboard.ReplaceVariable(this.resultPositionKey, iterator.Current);
            this.Return(true);
        }
    }
}