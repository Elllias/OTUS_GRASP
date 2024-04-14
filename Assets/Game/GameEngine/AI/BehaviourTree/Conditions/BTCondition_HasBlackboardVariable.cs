using System;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTCondition_HasBlackboardVariable : IBehaviourCondition
    {
        public IBlackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        public string blackboardKey;

        public BTCondition_HasBlackboardVariable(IBlackboard blackboard, string blackboardKey)
        {
            this.blackboard = blackboard;
            this.blackboardKey = blackboardKey;
        }

        public BTCondition_HasBlackboardVariable()
        {
        }

        public void Construct(IBlackboard blackboard, string blackboardKey)
        {
            this.blackboard = blackboard;
            this.blackboardKey = blackboardKey;
        }

        public bool IsTrue()
        {
            return this.blackboard.HasVariable(this.blackboardKey);
        }
    }
}