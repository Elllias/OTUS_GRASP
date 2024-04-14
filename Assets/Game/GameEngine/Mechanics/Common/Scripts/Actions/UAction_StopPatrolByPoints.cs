using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Stop Patrol By Points»")]
    public sealed class UAction_StopPatrolByPoints : MonoAction
    {
        [SerializeField]
        private UPatrolByPointsEngine engine; 
        
        public override void Do()
        {
            if (this.engine.IsPatrol)
            {
                this.engine.StopPatrol();
            }
        }
    }
}