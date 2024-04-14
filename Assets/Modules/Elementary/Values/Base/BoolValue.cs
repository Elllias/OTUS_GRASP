using System;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class BoolValue : IValue<bool>
    {
        public bool Current
        {
            get { return this.value; }
        }

        [SerializeField]
        private bool value;

        public BoolValue(bool value)
        {
            this.value = value;
        }
    }
}