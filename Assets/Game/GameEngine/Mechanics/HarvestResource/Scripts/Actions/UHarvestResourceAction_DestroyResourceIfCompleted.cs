using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Action «Destroy Resource If Completed»")]
    public sealed class UHarvestResourceAction_DestroyResourceIfCompleted : UHarvestResourceAction
    {
        public override void Do(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                operation.targetResource.Get<IComponent_Destoy>().Destroy();
            }
        }
    }
}