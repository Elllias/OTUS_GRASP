using System;
using UnityEngine;

namespace Game.GameEngine.GameResources
{
    [Serializable]
    public struct ResourceDataSerialized
    {
        [SerializeField]
        public string type;

        [SerializeField]
        public int value;

        public ResourceDataSerialized(string type, int value)
        {
            this.type = type;
            this.value = value;
        }
    }
}