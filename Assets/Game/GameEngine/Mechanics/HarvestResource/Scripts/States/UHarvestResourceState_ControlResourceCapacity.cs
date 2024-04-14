using Elementary;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource State «Control Resource Capacity»")]
    public sealed class UHarvestResourceState_ControlResourceCapacity : MonoState
    {
        [SerializeField]
        public UResourceSourceLimited resourceStorage;

        [SerializeField]
        public UHarvestResourceOperator harvestEngine;
        
        public override void Enter()
        {
            this.resourceStorage.OnValueChanged += this.OnResourceCountChanged;
        }

        public override void Exit()
        {
            this.resourceStorage.OnValueChanged -= this.OnResourceCountChanged;
        }

        private void OnResourceCountChanged(ResourceType resourceType, int newCount)
        {
            if (this.resourceStorage.IsLimit)
            {
                this.harvestEngine.Stop();
            }
        }
    }
}