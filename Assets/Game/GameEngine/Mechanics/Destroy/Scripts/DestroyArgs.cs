using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public struct DestroyArgs
    {
        [SerializeField]
        public DestroyReason reason;

        [SerializeField]
        public object source;
        
        public DestroyArgs(DestroyReason reason, object source = null)
        {
            this.reason = reason;
            this.source = source;
        }
    }
}