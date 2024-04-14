using AI.Blackboards;
using AI.BTree;
using Entities;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTCondition «Entity Conditions»")]
    public sealed class UBTCondition_CheckEntityConditions : UnityBehaviourCondition, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private ScriptableEntityCondition[] conditions;

        [BlackboardKey]
        [SerializeField]
        private string entityKey;

        public override bool IsTrue()
        {
            if (!this.Blackboard.TryGetVariable(this.entityKey, out IEntity entity))
            {
                return default;
            }

            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue(entity))
                {
                    return false;
                }
            }

            return true;
        }
    }
}