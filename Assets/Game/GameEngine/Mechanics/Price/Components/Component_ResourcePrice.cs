using System;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class Component_ResourcePrice : IComponent_ResourcePrice
    {
        [SerializeField]
        private ResourceData[] price;
        
        public ResourceData[] GetPrice()
        {
            return this.price;
        }
    }
}