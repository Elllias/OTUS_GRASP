using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Stop Move To Position»")]
    public sealed class UAction_StopMoveToPosition : MonoAction
    {
        [SerializeField]
        private UMoveToPositionMotor moveEngine;
        
        public override void Do()
        {
            if (this.moveEngine.IsMove)
            {
                this.moveEngine.StopMove();
            }
        }
    }
}