using System.Collections.Generic;
using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using Newtonsoft.Json;
using SaveSystem.Interfaces;

namespace SaveSystem.Systems
{
    public class GameRepository : IGameRepository
    {
        private readonly ISaveService _saveService;
        private const string STATE_DATA_KEY = "StateData.txt";
        
        private Dictionary<string, string> _gameState = new();

        public GameRepository(ISaveService saveService)
        {
            _saveService = saveService;
        }

        public void SetData<T>(T data)
        {
            var key = typeof(T).Name;
            var keyData = JsonConvert.SerializeObject(data);

            _gameState[key] = keyData;
        }

        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).Name;

            if (_gameState.TryGetValue(key, out var dataJson))
            {
                data = JsonConvert.DeserializeObject<T>(dataJson);
                return true;
            }
            
            data = default;
            return false;
        }

        public void SaveState()
        {
            var dataJson = JsonConvert.SerializeObject(_gameState);
            
            _saveService.Save(STATE_DATA_KEY, dataJson);
        }

        public void LoadState()
        {
            var dataJson = _saveService.Load(STATE_DATA_KEY);
            
            _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataJson);
        }
    }
}