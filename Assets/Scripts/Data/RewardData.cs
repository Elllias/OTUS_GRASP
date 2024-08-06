using System;
using Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class RewardData
    {
        [SerializeField] public RewardType RewardType;
        [SerializeField] public int Quantity;

        [SerializeField] public bool HasReference;
        [ShowIf(nameof(HasReference))] public ItemConfig RewardItem;
    }
}