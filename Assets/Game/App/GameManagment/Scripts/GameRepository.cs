using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services;
using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace Game.App
{
    public sealed class GameRepository
    {
        private const string SAVE_TIME_KEY = "saveTime";
        private const string GAME_PREFS = "GameState";
        
        private static readonly DateTime originTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private GameClient client;
        
        private Dictionary<string, string> gameState;
        private bool isSaving;

        [ServiceInject]
        public void Construct(GameClient client)
        {
            this.client = client;
        }

        public bool TryGetData(string key, out string data)
        {
            return this.gameState.TryGetValue(key, out data);
        }

        public string GetData(string data)
        {
            return this.gameState[data];
        }

        public void SetData(string key, string data)
        {
            this.gameState[key] = data;
        }

        public async Task LoadSynchronizedState()
        {
            //Load local game state:
            Dictionary<string, string> localState = new();
            long localSaveTime = -1; 
            if (PlayerPrefs.HasKey(GAME_PREFS))
            {
                var localJson = PlayerPrefs.GetString(GAME_PREFS);
                localState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
                localSaveTime = long.Parse(localState[SAVE_TIME_KEY]);
            }

            //Load remote game state:
            Dictionary<string, string> remoteState = new();
            long remoteSaveTime = -1;
            
            var (success, remoteJson) = await this.client.GetPlayerData();
            if (success)
            {
                Debug.Log($"DOWNLOADED DATA {remoteJson}");
                remoteState = JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson);
                remoteSaveTime = long.Parse(remoteState[SAVE_TIME_KEY]);   
            }

            //Select recent game state:
            if (remoteSaveTime > localSaveTime)
            {
                Debug.Log($"SELECT REMOTE DATA {remoteSaveTime}");
                this.gameState = remoteState;
            }
            else
            {
                Debug.Log($"SELECT LOCAL DATA {localSaveTime}");
                this.gameState = localState;
            }
        }

        public async Task<bool> LoadRemoteState()
        {
            var (success, remoteJson) = await this.client.GetPlayerData();
            if (success)
            {
                Debug.Log($"DOWNLOADED DATA {remoteJson}");
                this.gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(remoteJson);
                PlayerPrefs.DeleteKey(GAME_PREFS);
            }

            return success;
        }

        public void LoadLocalState()
        {
            if (PlayerPrefs.HasKey(GAME_PREFS))
            {
                var localJson = PlayerPrefs.GetString(GAME_PREFS);
                this.gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(localJson);
            }
        }

        public async void SaveAllStates()
        {
            if (this.isSaving)
            {
                return;
            }
            
            this.isSaving = true;
            
            //Update save time:
            var time = DateTime.Now.ToUniversalTime() - originTime;
            var saveTime = time.TotalSeconds.ToString("F0");
            this.gameState[SAVE_TIME_KEY] = saveTime;
            
            //Save game state:
            var json = JsonConvert.SerializeObject(this.gameState);
            PlayerPrefs.SetString(GAME_PREFS, json);
            await this.client.SetPlayerData(json);
            
            this.isSaving = false;
        }
    }
}