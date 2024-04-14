using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public struct TakeDamageArgs
    {
        [SerializeField]
        public int damage;

        [SerializeField]
        public TakeDamageReason reason;

        [SerializeField]
        public object source;

        public TakeDamageArgs(int damage, TakeDamageReason reason, object source = null)
        {
            this.damage = damage;
            this.reason = reason;
            this.source = source;
        }
    }
}