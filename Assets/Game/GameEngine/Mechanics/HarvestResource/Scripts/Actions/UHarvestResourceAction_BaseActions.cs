using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource Action «Base Actions»")]
    public sealed class UHarvestResourceAction_BaseActions : UHarvestResourceAction
    {
        [SerializeField]
        public MonoAction[] actions;
        
        public override void Do(HarvestResourceOperation operation)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}