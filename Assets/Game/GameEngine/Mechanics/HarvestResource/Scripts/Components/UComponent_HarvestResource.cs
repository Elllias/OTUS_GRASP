using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Component «Harvest Resource»")]
    public sealed class UComponent_HarvestResource : MonoBehaviour, IComponent_HarvestResource
    {
        public event Action<HarvestResourceOperation> OnHarvestStarted
        {
            add { this.harvestEngine.OnStarted += value; }
            remove { this.harvestEngine.OnStarted -= value; }
        }

        public event Action<HarvestResourceOperation> OnHarvestStopped
        {
            add { this.harvestEngine.OnStopped += value; }
            remove { this.harvestEngine.OnStopped -= value; }
        }

        public bool IsHarvesting
        {
            get { return this.harvestEngine.IsActive; }
        }

        [SerializeField]
        private UHarvestResourceOperator harvestEngine;

        public bool CanStartHarvest(HarvestResourceOperation operation)
        {
            return this.harvestEngine.CanStart(operation);
        }

        public void StartHarvest(HarvestResourceOperation operation)
        {
            this.harvestEngine.DoStart(operation);
        }

        public void StopHarvest()
        {
            this.harvestEngine.Stop();
        }
    }
}