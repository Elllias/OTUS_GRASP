using Elementary;
using UnityEngine;

namespace Game.GameEngine.GameResources
{
    public sealed class UCondition_IsLimitReached : MonoCondition
    {
        [SerializeField]
        private UResourceSourceLimited source;
        
        public override bool IsTrue()
        {
            return !this.source.IsLimit;
        }
    }
}