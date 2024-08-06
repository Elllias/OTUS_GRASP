using System;
using System.Linq;
using Configs;
using Data;
using Sirenix.OdinInspector;
using UI.TimePanel;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// Этот класс необходим для дебага системы реального времени.
    /// </summary>
    public class Debug : MonoBehaviour
    {
        [SerializeField] private ChestsConfig _chestsConfig;
        [SerializeField] private TimeView _timeView;
        
        private TimeSystem _timeSystem;
        private ChestsSystem _chestsSystem;
        private TimeViewObserver _timeViewObserver;
        
        private void Awake()
        {
            _timeSystem = new TimeSystem();
            _timeViewObserver = new TimeViewObserver(_timeView, _timeSystem);
            
            _chestsSystem = new ChestsSystem(_chestsConfig);
        }

        private void OnEnable()
        {
            _chestsSystem.OnChestOpened += OnChestOpened;
        }

        private void OnDisable()
        {
            _chestsSystem.OnChestOpened -= OnChestOpened;
        }

        private void Start()
        {
            _timeSystem.Initialize();
        }

        /// <summary>
        /// Имитация метода класса NetworkManager'а или аналога
        /// </summary>
        [Button]
        public void OnUserConnection(UserData userData)
        {
            _timeSystem.RecordCurrentTime(userData.Id, (int)TimeType.Connection);

            RecordChestTime(userData.Id, ChestType.WoodType);
            RecordChestTime(userData.Id, ChestType.SteelType);
            RecordChestTime(userData.Id, ChestType.GoldType);
        }
        
        /// <summary>
        /// Имитация метода класса NetworkManager'а или аналога
        /// </summary>
        [Button]
        public void OnUserDisconnection(UserData userData)
        {
            _timeSystem.RecordCurrentTime(userData.Id, (int)TimeType.Disconnection);
        }

        /// <summary>
        /// Имитация метода класса ChestsViewController или аналога
        /// </summary>
        [Button]
        public bool OpenChest(int userId, ChestType type)
        {
            var chestOpenTimeData = _timeSystem.GetLastTimeData(userId, (int)type);

            if (chestOpenTimeData.DateTime <= DateTime.Now)
            {
                if (_chestsSystem.OpenChest(type))
                {
                    _timeSystem.RecordTime(userId, (int)type, 
                        DateTime.Now.AddSeconds(_chestsSystem.GetChestData(type).OpeningSeconds), true);

                    return true;
                }
            }

            return false;
        }

        private void RecordChestTime(int userId, ChestType type)
        {
            var chestData = _chestsConfig.ChestsTimeData.FirstOrDefault(data => data.Type == type);

            if (chestData == null) return;
                
            _timeSystem.RecordTime(userId, (int)type, DateTime.Now.AddSeconds(chestData.OpeningSeconds), true);
        }
        
        /// <summary>
        /// Имитация метода в классе инверторя или хранилища. 
        /// </summary>
        private void OnChestOpened(RewardData data)
        {
            var text = string.Empty;

            text += $"Reward Time: {data.RewardType.ToString()}, ";

            if (data.HasReference)
            {
                text += $"Reward Item: {data.RewardItem.Name}, ";
            }

            text += $"Quantity: {data.Quantity}";
            
            UnityEngine.Debug.Log(text);
        }
    }
}