using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction Action «Base Actions»")]
    public sealed class UMoveInDirectionAction_BaseActions : UMoveInDirectionAction
    {
        [SerializeField]
        public MonoAction[] actions;
    
        public override void Do(Vector3 direction)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}