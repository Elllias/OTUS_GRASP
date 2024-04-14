using AI.Blackboards;
using AI.BTree;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Harvest Resource» (Entity)")]
    public sealed class UBTNode_Entity_HarvestResource : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;

        private IComponent_HarvestResource harvestComponent;

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.resourceKey, out IEntity resource))
            {
                this.Return(false);
                return;
            }

            this.harvestComponent = unit.Get<IComponent_HarvestResource>();
            this.harvestComponent.OnHarvestStopped += this.OnHarvestFinished;
            
            this.StartHarvest(resource);
        }

        private void StartHarvest(IEntity targetResource)
        {
            var operation = new HarvestResourceOperation(targetResource); 
            this.harvestComponent.StartHarvest(operation);
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                this.Return(true);
            }
            else
            {
                this.Return(false);
            }
        }

        protected override void OnAbort()
        {
            if (this.harvestComponent != null)
            {
                this.harvestComponent.OnHarvestStopped -= this.OnHarvestFinished;
                this.harvestComponent.StopHarvest();
                this.harvestComponent = null;   
            }
        }

        protected override void OnReturn(bool success)
        {
            if (this.harvestComponent != null)
            {
                this.harvestComponent.OnHarvestStopped -= this.OnHarvestFinished;
                this.harvestComponent = null;
            }
        }
    }
}