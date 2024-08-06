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
        
        public void RecordCurrentTime(int id, int type)
        {
            RecordTime(id, type, DateTime.Now);
        }

        public void RecordTime(int id, int type, DateTime time, bool isOverride = false)
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
                        UserId = id,
                        TimesData = new List<TimeData>
                            { new() { Type = type, DateTime = time } }
                    }
                };
                
                var jsonText = JsonConvert.SerializeObject(_usersTimeData);

                File.WriteAllText(filePath, jsonText);
                
                UsersTimeDataUpdated?.Invoke(_usersTimeData);
                return;
            }

            var userTimeData = _usersTimeData.FirstOrDefault(data => data.UserId == id);

            if (userTimeData == null)
            {
                userTimeData = new UserTimeData
                {
                    UserId = id,
                    TimesData = new List<TimeData> { new() { Type = type, DateTime = time } }
                };
                _usersTimeData.Add(userTimeData);
            }
            else
            {
                if (!isOverride)
                {
                    userTimeData.TimesData.Add(new TimeData { Type = type, DateTime = time });
                }
                else
                {
                    var timeData = userTimeData.TimesData.FirstOrDefault(data => data.Type == type);

                    userTimeData.TimesData.Remove(timeData);
                    timeData = new TimeData { Type = type, DateTime = time };
                    userTimeData.TimesData.Add(timeData);
                }
            }

            var json = JsonConvert.SerializeObject(_usersTimeData);

            File.WriteAllText(filePath, json);

            UsersTimeDataUpdated?.Invoke(_usersTimeData);
        }

        public TimeData GetLastTimeData(int userId, int type)
        {
            var userTimeData = _usersTimeData.FirstOrDefault(data => data.UserId == userId);

            if (userTimeData == null)
                throw new ArgumentException("UserId does not exist.");

            var timeData = userTimeData.TimesData.LastOrDefault(data => data.Type == type);

            if (timeData.Type == 0)
                throw new ArgumentException($"User doesn't have data with type {type}");
            
            return timeData;
        }
    }
}