using System;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public struct InventoryItemData
    {
        [SerializeField]
        public string name;

        [SerializeField]
        public int count;
    }
}