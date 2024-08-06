using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class ChestData
    {
        [SerializeField] public ChestType Type;
        [SerializeField] public int OpeningSeconds;
        [SerializeField] public List<RewardData> PossibleRewardsData;
    }
}