using System;
using System.Collections.Generic;
using Data;
using Sirenix.OdinInspector;
using UI.TimePanel;
using UnityEngine;

namespace Core
{
    public class NetworkManagerDebug : MonoBehaviour
    {
        [SerializeField] private TimeView _timeView;
        
        private TimeSystem _timeSystem;
        private TimeViewController _timeViewController;
        
        private void Awake()
        {
            _timeSystem = new TimeSystem();
            _timeViewController = new TimeViewController(_timeView, _timeSystem);
        }

        private void Start()
        {
            _timeSystem.Initialize();
        }

        [Button]
        public void OnUserConnection(UserData userData)
        {
            _timeSystem.RecordCurrentTime(userData.Id, TimeType.Connection);
        }
        
        [Button]
        public void OnUserDisconnection(UserData userData)
        {
            _timeSystem.RecordCurrentTime(userData.Id, TimeType.Disconnection);
        }

        [Button]
        public List<TimeData> GetAllTimeUser(UserData userData)
        {
            return _timeSystem.GetAllTimeUser(userData.Id);
        }
    }
}