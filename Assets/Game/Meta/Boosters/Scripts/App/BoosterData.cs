using System;
using UnityEngine;

namespace Game.Meta
{
    [Serializable]
    public struct BoosterData
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public float remainingTime;
    }
}