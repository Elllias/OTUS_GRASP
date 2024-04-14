using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_HarvestResource : IComponent_HarvestResource
    {
        public event Action<HarvestResourceOperation> OnHarvestStarted
        {
            add { this.harvestOperator.OnStarted += value; }
            remove { this.harvestOperator.OnStarted -= value; }
        }

        public event Action<HarvestResourceOperation> OnHarvestStopped
        {
            add { this.harvestOperator.OnStopped += value; }
            remove { this.harvestOperator.OnStopped -= value; }
        }

        public bool IsHarvesting
        {
            get { return this.harvestOperator.IsActive; }
        }

        private readonly IOperator<HarvestResourceOperation> harvestOperator;

        public Component_HarvestResource(IOperator<HarvestResourceOperation> harvestOperator)
        {
            this.harvestOperator = harvestOperator;
        }

        public bool CanStartHarvest(HarvestResourceOperation operation)
        {
            return this.harvestOperator.CanStart(operation);
        }

        public void StartHarvest(HarvestResourceOperation operation)
        {
            this.harvestOperator.DoStart(operation);
        }

        public void StopHarvest()
        {
            this.harvestOperator.Stop();
        }
    }
}