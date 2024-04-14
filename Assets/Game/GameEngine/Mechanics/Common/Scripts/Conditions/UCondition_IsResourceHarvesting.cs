using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Resource Harvesting»")]
    public sealed class UCondition_IsResourceHarvesting : MonoCondition
    {
        [SerializeField]
        public UHarvestResourceOperator engine;
        
        public override bool IsTrue()
        {
            return this.engine.IsActive;
        }
    }
}