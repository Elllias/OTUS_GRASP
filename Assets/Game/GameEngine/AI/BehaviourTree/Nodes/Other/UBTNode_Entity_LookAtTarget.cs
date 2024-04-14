using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Look At Target» (Entity)")]
    public sealed class UBTNode_Entity_LookAtTarget : UnityBehaviourNode, IBlackboardInjective 
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;
        
        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            var targetTransform = target.Get<IComponent_GetPosition>();
            var targetPosition = targetTransform.Position;
            unit.Get<IComponent_LookAtPosition>().LookAtPosition(targetPosition);
            this.Return(true);
        }
    }
}