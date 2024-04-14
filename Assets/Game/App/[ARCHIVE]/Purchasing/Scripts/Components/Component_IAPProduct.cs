using System;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public sealed class Component_IAPProduct : IComponent_IAPProduct
    {
        public string ProductId
        {
            get { return this.productId; }
        }

        [SerializeField]
        private string productId;
    }
}