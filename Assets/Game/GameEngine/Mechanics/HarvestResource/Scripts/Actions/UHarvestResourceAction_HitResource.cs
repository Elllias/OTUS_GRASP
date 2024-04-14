using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Action «Hit Resource»")]
    public sealed class UHarvestResourceAction_HitResource : UHarvestResourceAction
    {
        public override void Do(HarvestResourceOperation operation)
        {
            operation.targetResource.Get<IComponent_Hit>().Hit();
        }
    }
}