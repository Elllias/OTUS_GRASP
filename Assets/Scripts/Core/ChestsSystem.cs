using System;
using System.Linq;
using Configs;
using Data;
using Random = UnityEngine.Random;

namespace Core
{
    public class ChestsSystem
    {
        public event Action<RewardData> OnChestOpened;
        
        private readonly ChestsConfig _chestsConfig;

        public ChestsSystem(ChestsConfig chestsConfig)
        {
            _chestsConfig = chestsConfig;
        }

        public bool OpenChest(ChestType type)
        {
            var chestData = GetChestData(type);

            if (chestData == null) return false;

            var randomRewardIndex = Random.Range(0, chestData.PossibleRewardsData.Count);
            OnChestOpened?.Invoke(chestData.PossibleRewardsData[randomRewardIndex]);

            return true;
        }

        public ChestData GetChestData(ChestType type)
        {
            return _chestsConfig.ChestsTimeData.FirstOrDefault(data => data.Type == type);
        } 
    }
}