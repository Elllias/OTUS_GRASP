using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Newtonsoft.Json;
using UI.TimePanel;
using UnityEngine;

namespace Core
{
    public class TimeSystem
    {
        private const string TIME_FILE_NAME = "TIME.txt";

        public event Action<List<UserTimeData>> UsersTimeDataInitialized;
        public event Action<List<UserTimeData>> UsersTimeDataUpdated;

        private List<UserTimeData> _usersTimeData;

        public void Initialize()
        {
            var filePath = Path.Combine(Application.persistentDataPath, TIME_FILE_NAME);
            
            if (!File.Exists(filePath))
            {
                var fs = File.Create(filePath);
                fs.Dispose();
            }
            
            var usersTimeDataJson = File.ReadAllText(filePath);
            
            _usersTimeData
                = JsonConvert.DeserializeObject<List<UserTimeData>>(usersTimeDataJson)
                  ?? new List<UserTimeData>();
            
            UsersTimeDataInitialized?.Invoke(_usersTimeData);
        }
        
        public void RecordCurrentTime(int userId, TimeType timeType)
        {
            var filePath = Path.Combine(Application.persistentDataPath, TIME_FILE_NAME);
            
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            
            if (_usersTimeData.Count == 0)
            {
                _usersTimeData = new List<UserTimeData>
                {
                    new()
                    {
                        UserId = userId,
                        TimesData = new List<TimeData>
                            { new() { TimeType = timeType, DateTime = DateTime.Now } }
                    }
                };
                
                var jsonText = JsonConvert.SerializeObject(_usersTimeData);

                File.WriteAllText(filePath, jsonText);
                
                UsersTimeDataUpdated?.Invoke(_usersTimeData);
                return;
            }

            var userTimeData = _usersTimeData.FirstOrDefault(data => data.UserId == userId);

            if (userTimeData == null)
            {
                userTimeData = new UserTimeData
                {
                    UserId = userId,
                    TimesData = new List<TimeData> { new() { TimeType = timeType, DateTime = DateTime.Now } }
                };
                _usersTimeData.Add(userTimeData);
            }
            else
            {
                userTimeData.TimesData.Add(new TimeData { TimeType = timeType, DateTime = DateTime.Now });
            }

            var json = JsonConvert.SerializeObject(_usersTimeData);

            File.WriteAllText(filePath, json);

            UsersTimeDataUpdated?.Invoke(_usersTimeData);
        }

        public List<TimeData> GetAllTimeUser(int userId)
        {
            var filePath = Path.Combine(Application.persistentDataPath, TIME_FILE_NAME);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return new List<TimeData>();
            }
            
            var usersTimeDataJson = File.ReadAllText(filePath);

            var usersTimeData
                = JsonConvert.DeserializeObject<List<UserTimeData>>(usersTimeDataJson)
                  ?? new List<UserTimeData>();

            var userTimeData = usersTimeData.FirstOrDefault(data => data.UserId == userId);

            return userTimeData != null ? userTimeData.TimesData : new List<TimeData>();
        }
    }
}