using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Inspect Target Destroy»")]
    public sealed class UBTNode_InspectTargetDestroy : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private IComponent_OnDestroyed<DestroyArgs> targetComponent;

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            this.targetComponent = target.Get<IComponent_OnDestroyed<DestroyArgs>>();
            this.targetComponent.OnDestroyed += this.OnDestroyed;
        }

        protected override void OnDispose()
        {
            if (this.targetComponent != null)
            {
                this.targetComponent.OnDestroyed -= this.OnDestroyed;
                this.targetComponent = null;
            }
        }

        private void OnDestroyed(DestroyArgs destroyArgs)
        {
            this.Return(false);
        }
    }
}