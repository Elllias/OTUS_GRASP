using System;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public class BehaviourNodeCondition : BehaviourNode
    {
        [Space]
        [SerializeReference]
        public IBehaviourCondition condition;

        public BehaviourNodeCondition()
        {
        }

        public BehaviourNodeCondition(IBehaviourCondition condition)
        {
            this.condition = condition;
        }

        protected override void Run()
        {
            this.Return(this.condition.IsTrue());
        }
    }
}