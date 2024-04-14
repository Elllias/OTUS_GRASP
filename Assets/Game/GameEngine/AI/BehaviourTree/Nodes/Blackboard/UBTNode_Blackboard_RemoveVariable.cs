using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Has Blackboard Variable»")]
    public sealed class UBTNode_Blackboard_RemoveVariable : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string key;

        protected override void Run()
        {
            this.Blackboard.RemoveVariable(this.key);
        }
    }
}