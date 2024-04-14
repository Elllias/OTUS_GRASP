using System;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public struct UpgradeData
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public int level;
    }
}