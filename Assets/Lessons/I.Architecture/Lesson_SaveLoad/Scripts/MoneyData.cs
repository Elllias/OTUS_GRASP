using System;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    [Serializable]
    public struct MoneyData
    {
        [SerializeField]
        public int money;
    }
}