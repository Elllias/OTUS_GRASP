using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Hit Points Exists»")]
    public sealed class UCondition_IsHitPointsExists : MonoCondition
    {
        [SerializeField]
        public UHitPoints engine;
        
        public override bool IsTrue()
        {
            return this.engine.Current > 0;
        }
    }
}