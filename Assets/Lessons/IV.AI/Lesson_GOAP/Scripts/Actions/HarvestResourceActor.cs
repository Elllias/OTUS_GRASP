using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HarvestResourceActor : Actor, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private int cost = 1;

        [BlackboardKey]
        [SerializeField, Space]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;

        private IComponent_HarvestResource harvestComponent;

        public override int EvaluateCost()
        {
            return this.cost;
        }

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.resourceKey);
        }

        protected override void Play()
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
            this.TryStartHarvest(resource);
        }

        private void TryStartHarvest(IEntity resource)
        {
            var operation = new HarvestResourceOperation(resource);
            if (this.harvestComponent.CanStartHarvest(operation))
            {
                this.harvestComponent.OnHarvestStopped += this.OnHarvestFinished;
                this.harvestComponent.StartHarvest(operation);
            }
            else
            {
                this.Return(false);
            }
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (this.harvestComponent != null)
            {
                this.harvestComponent.OnHarvestStopped -= this.OnHarvestFinished;
                this.harvestComponent = null;
            }
            
            this.Return(operation.isCompleted);
        }

        protected override void OnCancel()
        {
            if (this.harvestComponent != null)
            {
                this.harvestComponent.OnHarvestStopped -= this.OnHarvestFinished;
                this.harvestComponent.StopHarvest();
                this.harvestComponent = null;   
            }
        }
    }
}