using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Melee Combat/Move To Position Action «Base Actions»")]
    public class UMoveToPositionAction_BaseActions : UMoveToPositionAction
    {
        [SerializeField]
        public MonoAction[] actions;
        
        public override void Do(Vector3 targetPosition)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}