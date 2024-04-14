using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Condition «Is Hit Points Full»")]
    public sealed class UCondition_IsHitPointsFull : MonoCondition
    {
        [SerializeField]
        public UHitPoints engine;
        
        public override bool IsTrue()
        {
            return this.engine.Current >= this.engine.Max;
        }
    }
}