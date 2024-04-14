using System;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [Serializable]
    public struct ConveyorData
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public int inputAmount;

        [SerializeField]
        public int outputAmount;
    }
}