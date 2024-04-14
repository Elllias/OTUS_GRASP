using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class Component_Effect : IComponent_GetEffect
    {
        public IEffect Effect
        {
            get { return this.effect; }
        }
        
        [SerializeReference]
        private IEffect effect = default;
    }
}