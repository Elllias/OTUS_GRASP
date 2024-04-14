using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Action «Look At Resource»")]
    public sealed class UHarvestResourceAction_LookAtResource : UHarvestResourceAction
    {
        [SerializeField]
        private UTransformEngine engine;
        
        public override void Do(HarvestResourceOperation operation)
        {
            var targetPosition = operation.targetResource.Get<IComponent_GetPosition>().Position;
            this.engine.LookAtPosition(targetPosition);
        }
    }
}