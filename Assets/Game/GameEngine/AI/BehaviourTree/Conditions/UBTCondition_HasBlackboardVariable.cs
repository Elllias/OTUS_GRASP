using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTCondition «Has Blackboard Variable»")]
    public sealed class UBTCondition_HasBlackboardVariable : UnityBehaviourCondition, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string variableKey;
        
        public override bool IsTrue()
        {
            var hasValue = this.Blackboard.HasVariable(this.variableKey);
            return hasValue;
        }
    }
}