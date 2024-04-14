using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Action «Add Resources To Source»")]
    public sealed class UHarvestResourceAction_AddResourcesToSource : UHarvestResourceAction
    {
        [SerializeField]
        public UResourceSource source;

        public override void Do(HarvestResourceOperation operation)
        {
            if (!operation.isCompleted)
            {
                return;
            }

            var resourceObject = operation.targetResource;
            var resourceType = resourceObject.Get<IComponent_GetResourceType>().Type;
            var amount = resourceObject.Get<IComponent_GetResourceCount>().Count;
            this.source.Plus(resourceType, amount);
        }
    }
}